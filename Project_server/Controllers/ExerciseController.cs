using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using AutoMapper;

/// <summary>
/// using the tables:
///     1. tbl_Exercises
///     2.  tbl_Words_per_exercise
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ExerciseController : ControllerBase
{
    IMapper mapper;
    IExerciseBL exerciseBL;
    public ExerciseController(IExerciseBL exerciseBL, IMapper mapper )
    {
        this.mapper = mapper;
        this.exerciseBL = exerciseBL;
    }
    // GET: api/<ExerciseController>
    /// screens:
    /// 1. SpeechTherapist -> exercise (Screen) -> PronunciationProblemsType -> Difficultylevel
    [HttpGet("{difficultylevelId}")]
    public async Task<List<TblExercise>> Get(int difficultylevelId)
    {
        // return all the exercise of this level;
        return await exerciseBL.GetExercises(difficultylevelId);
    }
    // GET: api/<ExerciseController>
    /// screens:
    /// 1. SpeechTherapist -> exercise (Screen) -> PronunciationProblemsType -> Difficultylevel-> exercise 
    [HttpGet("{exerciseId}/getWordsForExercise")]
    public async Task<List<WordExerciseDTO>> GetExerciseWords(int exerciseId)
    {
          // return all the words of this exercise;
      return mapper.Map<List<TblWordsPerExercise>, List<WordExerciseDTO>>(await exerciseBL.GetExerciseWords(exerciseId));
        
    }

    // POST api/<ExerciseController>
    /// screens:
    /// 1. SpeechTherapist -> Level -> addExercises
    [HttpPost("/PostExercise")]
    public async Task Post( [FromBody] TblExercise exercise)
    {
        //add new Exercise to this level
       await exerciseBL.PostExercise(exercise);
    }
    /// screens:
    /// 1. SpeechTherapist -> Level -> Exercise ->addWord
    [HttpPost("/AddWordPerExercise")]
    public async Task PostWordPerExercise([FromBody] TblWordsPerExercise wordPerExercise)
    {
        //add new word to this Exercises
        await exerciseBL.PostWordPerExercise(wordPerExercise);//mapper.Map<WordExerciseDTO,TblWordsPerExercise>(wordPerExercise));
    }

    // PUT api/<ExerciseController>/5
    /// screens:
    /// 1. SpeechTherapist -> Level -> editExercises
    [HttpPut("/PutExercise")]
    public async Task Put([FromBody] TblExercise exercise)
    {
        // change Exercise
        await exerciseBL.PutExercise(exercise);
    }

    // DELETE api/<ExerciseController>/5
    /// screens:
    /// 1. SpeechTherapist -> Level -> deleteExercises
    [HttpDelete("{exerciseId}")]
    public async Task DeleteExercise(int exerciseId)
    {
        //delete Exercises
        await exerciseBL.DeleteExercise(exerciseId);
    }

    [HttpDelete("{wordId}/DeleteWord")]
    public async Task DeleteWordFromExercise(int wordId)
    {
        //delete word fromExercises
        await exerciseBL.DeleteWordFromExercise(wordId);
    }
}

