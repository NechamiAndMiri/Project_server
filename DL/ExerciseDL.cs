using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ExerciseDL : IExerciseDL
    {
        GeneralDBContext generalDBContext; 
        public ExerciseDL(GeneralDBContext generalDBContext)
        {
            this.generalDBContext = generalDBContext;
        }

        public async Task<List<TblExercise>> GetExercises(int difficultylevelId)
        {
            return await generalDBContext.TblExercises.Where<TblExercise>(e => e.DifficultyLevelId == difficultylevelId).ToListAsync();
        }

        public async Task<List<TblWordsPerExercise>> GetExerciseWords(int exerciseId)
        {
            return await generalDBContext.TblWordsPerExercises.Where(w=>w.ExerciseId==exerciseId).Include(w=>w.Word).ToListAsync();
        }

        public async Task PostExercise(TblExercise exercise)
        {
             await generalDBContext.TblExercises.AddAsync(exercise);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task PostWordPerExercise(TblWordsPerExercise wordPerExercise)
        {
               await generalDBContext.TblWordsPerExercises.AddAsync(wordPerExercise);
               await generalDBContext.SaveChangesAsync();
        }

        public async Task PutExercise(TblExercise exercise)
        {
            TblExercise exercise1 = await generalDBContext.TblExercises.FindAsync(exercise.Id);
            generalDBContext.Entry(exercise1).CurrentValues.SetValues(exercise);
            await generalDBContext.SaveChangesAsync();
           
        }


        public async Task DeleteExercise(int exerciseId)
        {
            TblExercise exercise = await generalDBContext.TblExercises.FindAsync(exerciseId);
            foreach (var word in generalDBContext.TblWordsPerExercises)
            {
                if (word.ExerciseId == exerciseId)
                {
                    DeleteWordFromExercise(word.Id);
                }
            }
            generalDBContext.TblExercises.Remove(exercise);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task DeleteWordFromExercise(int wordId)
        {
            TblWordsPerExercise wordPerExercise = await generalDBContext.TblWordsPerExercises.FindAsync(wordId);
            generalDBContext.TblWordsPerExercises.Remove(wordPerExercise);
            await generalDBContext.SaveChangesAsync();
        }

    }
}
