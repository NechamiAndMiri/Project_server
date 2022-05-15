
using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// using the tables:
///     1. tbl_Lessons
///     2. tbl_Words_given_to_practice
/// </summary>
namespace Project_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        ILessonBL lessonBL;
        IMapper mapper;

        public LessonController(ILessonBL lessonBL, IMapper mapper)
        {
            this.lessonBL = lessonBL;
            this.mapper = mapper;
        }

        /// screens:
        /// 1. SpeechTherapist->patients->lessons
        /// 2. patient
        // GET: api/<LessonController>
        [HttpGet("{patientID}")]
        public async Task<List<LessonDTO>> GetAllLessons(int patientID)
        {
            // get all lessons
            var less = await lessonBL.GetAllLessons(patientID);
            return mapper.Map<List<TblLesson>, List<LessonDTO>>(less);
        }

        /// screens:
        /// 1. SpeechTherapist->patients->lessons->show
        /// 2.patient->lesson
        // GET: api/<LessonController>
        [HttpGet("get_all_WORDS_FOR_lesson/{lessonID}")]
        public async Task<List<WordsGivenToPracticeDTO>> GetLessonWords(int lessonID)
        {
            // get all WORDS FOR lesson
            var words = await lessonBL.GetLessonWords(lessonID);
            return mapper.Map<List<TblWordsGivenToPractice>, List<WordsGivenToPracticeDTO>>(words);
        }


        /// screens:
        /// 1. SpeechTherapist->patients->lessons->add

        // POST api/<LessonController>
        [HttpPost]
        public async Task<LessonDTO> Post([FromBody] TblLesson tblLesson)
        {
            //add the lesson
            return await lessonBL.PostLesson(tblLesson);
        }

        /// screens:
        /// 1. SpeechTherapist->patients->lessons->addwords2lesson

        // POST api/<LessonController>
        [HttpPost("/PostWordToLesson")]
        public async Task Post([FromBody] TblWordsGivenToPractice WordGivenToPractice)
        {
            //add the word to the lesson
            await lessonBL.PostWordToLesson(WordGivenToPractice);
        }

        static TblWordsGivenToPractice pratciceWord;
        [HttpPut]
        [Route("getWordToUpdate")]
        //public async Task UpdateRecording(int wordId)
        public void UpdateRecordingWord([FromBody] WordsGivenToPracticeDTO word)
        {

            pratciceWord =  mapper.Map<WordsGivenToPracticeDTO, TblWordsGivenToPractice>(word);
        }
        [HttpPut]
        [Route("UpdateRecording")]
        //public async Task UpdateRecording(int wordId)
       public async Task UpdateRecording()
        {
            var file = Request.Form.Files[0];
            //string filePath = Path.GetFullPath("recordings/ofPatient/" + file.FileName);
            string filePath = Path.Combine("recordings", "ofPatient", file.FileName);

            //כדי לשלוף את הנתיב המלא לכתוב כך:
            //string t  = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            //await lessonBL.PutWordRecording(wordId,filePath);
            await lessonBL.PutWordRecording(pratciceWord, filePath);
        }

        

            // PUT api/<LessonController>/5
            [HttpPut("/lesson")]
        public async Task PutLesson([FromBody] TblLesson tblLesson)
        {
            await lessonBL.PutLesson(tblLesson);
        }

        // PUT api/<LessonController>/5
        [HttpPut("/word")]
        public async Task PutWordForLesson([FromBody] TblWordsGivenToPractice word)
        {
            await lessonBL.PutWordForLesson(word);
        }

        /// screens:
        /// 1. SpeechTherapist->patients->lessons->edit
        // PUT api/<LessonController>/5
        [HttpPut("{lessonId}/edit_the_coulmn_isChecked")]
        public async Task PutColIsCheckedAtLesson(int lessonId)
        {
            //edit the coulmn isChecked
            await lessonBL.PutColIsCheckedAtLesson(lessonId);

        }

        /// screens:
        /// 1. SpeechTherapist->patients->lessons->editword
        // PUT api/<LessonController>/5
        [HttpPut("{wordId}/edit_the_coulmn_isvalid")]
        public async Task PutColIsValidAtWordToPractice(int wordId)
        {
            //edit the coulmn isvalid
            await lessonBL.PutColIsValidAtWordToPractice(wordId);
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{lessonId}/DeleteLesson")]
        public async Task DeleteLesson(int lessonId)
        {
            await lessonBL.DeleteLesson(lessonId);
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{wordId}/DeleteWordFromLesson")]
        public async Task DeleteWordFromLesson(int wordId)
        {
            await lessonBL.DeleteWordFromLesson(wordId);
        }
    }
}

