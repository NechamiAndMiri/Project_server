using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// using the tables:
///     1. tbl_Exercises
///     2.  tbl_Words_per_exercise
/// </summary>

public class ExerciseController : ControllerBase
{
    IExerciseBL exerciseBL;
    public ExerciseController(IExerciseBL exerciseBL)
    {
        this.exerciseBL = exerciseBL;
    }
    // GET: api/<ExerciseController>
    /// screens:
    /// 1. SpeechTherapist -> exercise (Screen) -> PronunciationProblemsType -> Difficultylevel
    [HttpGet]
    public IEnumerable<TblExercise> Get([FromBody] TblDifficultyLevel level)
    {
        // return all the exercise of this level;
        return null;
    }
    /// screens:
    /// 1. SpeechTherapist -> exercise (Screen) -> PronunciationProblemsType -> Difficultylevel-> exercise 
    [HttpGet]
    public IEnumerable<TblWord> Get([FromBody] TblExercise exercise)
    {
        // return all the exercise of this level;
        return null;
    }

    // POST api/<ExerciseController>
    /// screens:
    /// 1. SpeechTherapist -> Level -> addExercises
    [HttpPost("{ExerciseName}")]
    public void Post([FromBody] TblDifficultyLevel level,  string ExerciseName)
    {
        //add new Exercise to this level
    }
    /// screens:
    /// 1. SpeechTherapist -> Level -> Exercise ->addWord
    [HttpPost("{WordId}")]
    public void Post([FromBody] TblExercise exercise,  string WordId)
    {
        //add new word to this Exercises
    }

    // PUT api/<ExerciseController>/5
    /// screens:
    /// 1. SpeechTherapist -> Level -> editExercises
    [HttpPut("{ExerciseName}")]
    public void Put([FromBody] int id,  string ExerciseName)
    {
        // change Exercise name
    }


    [HttpPut("{id}")]
    /// screens:
    /// 1. SpeechTherapist -> Level -> Exercise ->editWord
    public void Put(int id, [FromBody] TblWord word)
    {
        // change word
    }

    // DELETE api/<ExerciseController>/5
    /// screens:
    /// 1. SpeechTherapist -> Level -> deleteExercises
    [HttpDelete("{id}")]
    public void Delete(int id, [FromBody] int tbl)
    {
        //delete Exercises or word fromExercises
    }
}

