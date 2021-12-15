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
        public IEnumerable<TblLesson> Get(int patientID)
        {
            // get all lessons
            return null;
        }

        /// screens:
        /// 1. SpeechTherapist->patients->lessons->show
        /// 2.patient->lesson
        // GET: api/<LessonController>
        [HttpGet("{lessonID}")]
        public IEnumerable<TblWordsGivenToPractice> Get(int lessonID,bool n)
        {
            // get all WORDS FOR lesson
            return null;
        }

        
        /// screens:
        /// 1. SpeechTherapist->patients->lessons->add

        // POST api/<LessonController>
        [HttpPost]
        public void Post([FromBody] TblLesson lesson)
        {
            //add the lesson
        }

        /// screens:
        /// 1. SpeechTherapist->patients->lessons->addwords2lesson

        // POST api/<LessonController>
        [HttpPost("{lessonID}/{wordID}")]
        public void Post( int wordID,  int lessonID)
        {
            //add the word to the lesson
        }

        /// screens:
        /// 1. SpeechTherapist->patients->lessons->edit
        // PUT api/<LessonController>/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
            //edit the coulmn isChecked
        }

        /// screens:
        /// 1. SpeechTherapist->patients->lessons->editword
        // PUT api/<LessonController>/5
        [HttpPut("{id}/{n}")]
        public void Put(int id,bool n)
        {
            //edit the coulmn isvalid
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
