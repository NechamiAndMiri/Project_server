
using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public LessonController(ILessonBL lessonBL)
        {
            this.lessonBL = lessonBL;
        }

        /// screens:
        /// 1. SpeechTherapist->patients->lessons
        /// 2. patient
        // GET: api/<LessonController>
        [HttpGet("{patientID}")]
        public async Task<List<TblLesson>> GetAllLessons(int patientID)
        {
            // get all lessons
            return await lessonBL.GetAllLessons(patientID);
        }

        /// screens:
        /// 1. SpeechTherapist->patients->lessons->show
        /// 2.patient->lesson
        // GET: api/<LessonController>
        [HttpGet("{lessonID}/get_all_WORDS_FOR_lesson")]
        public async Task<List<TblWordsGivenToPractice>> GetLessonWords(int lessonID)
        {
            // get all WORDS FOR lesson
            return await lessonBL.GetLessonWords(lessonID);
        }


        /// screens:
        /// 1. SpeechTherapist->patients->lessons->add

        // POST api/<LessonController>
        [HttpPost]
        public async Task Post([FromBody] TblLesson tblLesson)
        {
            //add the lesson
            await lessonBL.PostLesson(tblLesson);
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

