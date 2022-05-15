using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// //this controller controls the problems, levels and words for level
/// using the tables:
///     1. tbl_Pronunciation_problems_types
///     2. tbl_Difficulty_levels
///     3. tbl_Words
/// </summary>
namespace Project_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {

        IWordBL wordBL;

        public WordController(IWordBL wordBL)
        {
            this.wordBL = wordBL;
        }
        //להלן פונקציות הGET

        // GET: api/<WordController>
        /// screens:
        /// 1. SpeechTherapist -> exercise
        [HttpGet]
        public async Task<List<TblPronunciationProblemsType>> Get()
        {
            // return all the PronunciationProblemsTypes;
            return await wordBL.GetAllPronunciationProblemsTypes();

        }
        /// screens:
        /// 1. SpeechTherapist -> exercise -> PronunciationProblemsType
        [HttpGet("{problemsTypeId}/{speechTherapistId}/PronunciationProblemLevels")]
        public async Task<List<TblDifficultyLevel>> GetAllLevels(int problemsTypeId, int speechTherapistId)
        {
            // return all the level of this Pronunciation Problem
            return await wordBL.GetAllLevels(problemsTypeId, speechTherapistId);
        }
        /// screens:
        /// 1. SpeechTherapist -> exercise -> PronunciationProblemsType -> Difficultylevel
        [HttpGet("{levelId}/LevelWords")]
        public async Task<List<TblWord>> Get(int levelId)
        {
            // return all the words of this level;
            return await wordBL.GetAllWords(levelId);
        }

        [HttpGet("{word_id}/{wordText}/getRecord")]
        public async Task<FileStreamResult> GetRecord(int word_id, string wordText)
        {
            string recordName = wordText + "_record";
            string localRecordPath;
            // int fileSize;

            Task<string> t = wordBL.getLocalRecordPath(word_id);
            string filePath = t.Result;
            //string filePath = Directory.GetCurrentDirectory() + @"\audio\Processed\" + recordingFile;
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            //var types = GetMimeTypes();
            var ext = Path.GetExtension(filePath).ToLowerInvariant();
            return File(memory, /*types[ext], recordingFile*/"audio/mpeg",true );
            //get specified 
            //if (String.IsNullOrEmpty(wordText))
            //    return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            //string recordName = wordText+"_record";
            //string localRecordPath;
            //// int fileSize;

            //Task<string> t = wordBL.getLocalRecordPath(word_id);
            //localRecordPath = t.Result;

            //// localFilePath = getFileFromID(id, out fileName, out fileSize);

            //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StreamContent(new FileStream(localRecordPath, FileMode.Open, FileAccess.Read));
            //response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            //response.Content.Headers.ContentDisposition.FileName = recordName;
            //response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/mpeg");

            //return response;

        }

        //למחוק!!!!!!!!!!!!!!!!!!!!!
        //public HttpResponseMessage GetFile(int word_id,string wordText)
        //{
        //    if (String.IsNullOrEmpty(wordText))
        //        return new HttpResponseMessage(HttpStatusCode.Unauthorized);

        //    string recordName=wordText;
        //    string localRecordPath;
        //    // int fileSize;

        //    Task<string> t = wordBL.getLocalRecordPath(word_id);
        //    localRecordPath = t.Result;

        //    // localFilePath = getFileFromID(id, out fileName, out fileSize);

        //    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //    response.Content = new StreamContent(new FileStream(localRecordPath, FileMode.Open, FileAccess.Read));
        //    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        //    response.Content.Headers.ContentDisposition.FileName = recordName;
        //    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/mpeg");

        //    return response;
        //}


        // POST api/<WordController>
        /// screens:
        /// 1. SpeechTherapist -> addLevel
        [HttpPost]
        public async Task<TblDifficultyLevel>  PostLevel([FromBody] TblDifficultyLevel difficultyLevel )
        {
            //add new level to this problem
            return await wordBL.PostLevel(difficultyLevel);
        }


    static TblWord speechTherapistWord;
        /// screens:
        /// 1. SpeechTherapist -> Level -> addWord
        [HttpPost]
        [Route("word")]
        public async Task StartPostWord([FromBody]TblWord word)
        {
            //add new word to this level
            speechTherapistWord = word;
        }
        

        [HttpPost]
        [Route("PostWordRecording")]
        //public async Task UpdateRecording(int wordId)
        public async Task UpdateRecording()
        {
            //לבדוק את הפונקציה הזו טוב, האם צריך לחלק לשתיים עבור הפעם הראשונה שמכניסים הקלטה ועבור עדכון של מילה שלמה

            var file = Request.Form.Files[0];

            //string filePath = Path.GetFullPath("recordings/words/" + file.FileName);
            string filePath = Path.Combine("recordings","words" , file.FileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            //await lessonBL.PutWordRecording(wordId,filePath);

            //מחיקת ההקלטה הישנה שהייתה למילה
            //string oldRecord = speechTherapistWord.WordRecording;
            //if (oldRecord.Length > 0)
            //    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), oldRecord));

            speechTherapistWord.WordRecording = filePath;

            await wordBL.PostWord(speechTherapistWord);
        }


        // PUT api/<WordController>/5

        [HttpPut("{id}/{levelName}")]
        /// screens:
        /// 1. SpeechTherapist -> editLevel
        public async Task<bool> Put(int id, int levelName)
        {
            //change level name
           return await wordBL.PutLevel(id, levelName);
        }

        [HttpPut]
        /// screens:
        /// 1. SpeechTherapist -> Level ->edit word
        public async Task Put([FromBody] TblWord tblWord)
        {
            //change word
            await wordBL.PutWord(tblWord);
        }


        /// screens:
        /// 1. SpeechTherapist -> deleteLevel
        /// 2.SpeechTherapist -> deleteword

        // DELETE api/<WordController>/5
        [HttpDelete("{wordId}/deleteWord")]
        public async Task DeleteWord(int wordId)
        {
            //delete the word from the level 
            await wordBL.DeleteWord(wordId);

        }

        // DELETE api/<WordController>/5
        [HttpDelete("{levelId}/deleteAllLevelWords")]
        public async Task DeleteLevel(int levelId)
        {
            //delete all the words at the level
            await wordBL.DeleteLevel(levelId);
        }


        

    }


}
