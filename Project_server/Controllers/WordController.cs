using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IEnumerable<TblPronunciationProblemsType>> Get()
        {
            // return all the PronunciationProblemsTypes;
            return await wordBL.GetAllPronunciationProblemsTypes();
            
        }
        /// screens:
        /// 1. SpeechTherapist -> exercise -> PronunciationProblemsType
        [HttpGet("{problemsTypeId}/PronunciationProblemLevels")]
        public async Task<IEnumerable<TblDifficultyLevel>> GetAllLevels(int problemsTypeId)
        {
            // return all the level of this Pronunciation Problem
            return await wordBL.GetAllLevels(problemsTypeId);
        }
        /// screens:
        /// 1. SpeechTherapist -> exercise -> PronunciationProblemsType -> Difficultylevel
        [HttpGet("{levelId}")]
        public IEnumerable<TblWord> Get(int levelId)
        {
            // return all the words of this level;
            return null;
        }


        // POST api/<WordController>
        /// screens:
        /// 1. SpeechTherapist -> addLevel
        [HttpPost("{pronunciationProblemId/addLevel}")]
        public async Task PostLevel(int pronunciationProblemId )
        {
            //add new level to this problem
             await wordBL.PostLevel(pronunciationProblemId);
        }

        /// screens:
        /// 1. SpeechTherapist -> Level -> addWord
        [HttpPost("{word}")]
        public void PostWord([FromBody] TblDifficultyLevel level, string word)
        {
            //add new word to this level
        }

        // PUT api/<WordController>/5

        [HttpPut("{id}/{levelName}")]
        /// screens:
        /// 1. SpeechTherapist -> editLevel
        public void Put(string id, int levelName)
        {
            //change level name
        }

        [HttpPut("{id}")]
        /// screens:
        /// 1. SpeechTherapist -> Level ->edit word
        public void Put(string id, [FromBody] TblWord word)
        {
            //change word
        }

        /// screens:
        /// 1. SpeechTherapist -> deleteLevel
        /// 2.SpeechTherapist -> deleteword

        // DELETE api/<WordController>/5
        [HttpDelete("{levelId}/{wordId}")]
        public void Delete(int levelId, int wordId = 0)
        {
            //delete the word from the level, 
            //if the id=0 delete all the words at the level
        }

    }


}
