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

        [HttpGet("{wordGivenToPracticeId}/GetWordToPractice")]
        public async Task<TblWordsGivenToPractice> GetWordToPractice(int wordGivenToPracticeId)
        {
            return await wordBL.GetWordToPractice(wordGivenToPracticeId);
        }

        [HttpGet("{word_id}/getRecord")]
        public async Task<FileStreamResult> GetRecord(int word_id)
        {
            Task<string> t = wordBL.getLocalRecordPath(word_id);

            string filePath = t.Result;
            var memory = new MemoryStream();

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return File(memory,"audio/mpeg",true );
        }

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
        public async Task PostWordRecording()
        {
            var file = Request.Form.Files[0];
            string filePath = Path.Combine("recordings","words" , file.FileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
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

        [HttpPut("PutWordRecording")]
        /// screens:
        /// 1. SpeechTherapist -> editLevel
        public async Task PutWord()
        {
            var file = Request.Form.Files[0];

            //string filePath = Path.GetFullPath("recordings/words/" + file.FileName);
            string filePath = Path.Combine("recordings", "words", file.FileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            //מחיקת ההקלטה הישנה שהייתה למילה
            string oldRecord = speechTherapistWord.WordRecording;
            speechTherapistWord.WordRecording = filePath;
            if (oldRecord.Length > 0)
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), oldRecord)); 
            }
            await wordBL.PutWord(speechTherapistWord);
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
