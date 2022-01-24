using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class WordDL : IWordDL
    {
        GeneralDBContext generalDBContext;
        public WordDL()     
        {
            generalDBContext = new GeneralDBContext();
        }

        public async Task<List<TblDifficultyLevel>> GetAllLevels(int problemsTypeId)
        {
           return await generalDBContext.TblDifficultyLevels.Where(l => l.PronunciationProblemId == problemsTypeId).ToListAsync();
        }

        public async Task<List<TblPronunciationProblemsType>> GetAllPronunciationProblemsTypes()
        {
            return await generalDBContext.TblPronunciationProblemsTypes.ToListAsync();
        }

        public async Task<List<TblWord>> GetAllWords(int levelId)
        {
            return await generalDBContext.TblWords.Where(w=>w.DifficultyLevelId==levelId).ToListAsync();
        }

        public async Task PostLevel(TblDifficultyLevel difficultyLevel)
        {

            await generalDBContext.TblDifficultyLevels.AddAsync(difficultyLevel);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task PostWord(TblWord word)
        {
            await generalDBContext.TblWords.AddAsync(word);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task DeleteLevel(int levelId)
        {
            //delete all the words at the level
            TblDifficultyLevel difficultyLevel = await generalDBContext.TblDifficultyLevels.FindAsync(levelId);

            foreach (var word in generalDBContext.TblWords)
            {
                if (word.DifficultyLevelId == levelId)
                {
                    DeleteWord(word.Id);
                }
            }
            generalDBContext.TblDifficultyLevels.Remove(difficultyLevel);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task DeleteWord(int wordId)
        {
            //delete the word from the level 
            TblWord word = await generalDBContext.TblWords.FindAsync(wordId);
            generalDBContext.TblWords.Remove(word);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task PutLevel(int id, int levelName)
        {
            TblDifficultyLevel level = await generalDBContext.TblDifficultyLevels.FindAsync(id);
            var tmp = generalDBContext.Entry(level);
             level.DifficultyLevel = levelName;
             tmp.CurrentValues.SetValues(level);
            await generalDBContext.SaveChangesAsync();
           
        }

        public async Task PutWord(TblWord tblWord)
        {
            TblWord word = await generalDBContext.TblWords.FindAsync(tblWord.Id);
            if (word == null)
            {
                return;
            }
            generalDBContext.Entry(word).CurrentValues.SetValues(tblWord);
            await generalDBContext.SaveChangesAsync();
        }

    }
}
