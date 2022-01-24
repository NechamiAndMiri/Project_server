using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class ExerciseBL : IExerciseBL
    {
        IExerciseDL exerciseDL;
        public ExerciseBL(IExerciseDL exerciseDL)
        {
            this.exerciseDL = exerciseDL;
        }

        public async Task<List<TblExercise>> GetExercises(int difficultylevelId)
        {
            return await exerciseDL.GetExercises(difficultylevelId);
        }

        public async Task<List<TblWordsPerExercise>> GetExerciseWords(int exerciseId)
        {
            return await exerciseDL.GetExerciseWords(exerciseId);
        }

        public async Task PostExercise(TblExercise exercise)
        {
            await exerciseDL.PostExercise(exercise);
        }

        public async Task PostWordPerExercise(TblWordsPerExercise wordPerExercise)
        {
            await exerciseDL.PostWordPerExercise(wordPerExercise);
        }

        public async Task PutExercise(TblExercise exercise)
        {
            await exerciseDL.PutExercise(exercise);
        }


        public async Task DeleteExercise(int exerciseId)
        {
            await exerciseDL.DeleteExercise(exerciseId);
        }

        public async Task DeleteWordFromExercise(int wordId)
        {
            await exerciseDL.DeleteWordFromExercise(wordId);
        }

    }
}
