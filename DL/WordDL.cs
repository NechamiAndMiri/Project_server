using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class WordDL : IWordDL
    {
        GeneralDBContext generalDBContext;
        public WordDL(GeneralDBContext generalDBContext)     
        {
           this.generalDBContext= generalDBContext ;
        }

        public async Task<List<TblDifficultyLevel>> GetAllLevels(int problemsTypeId, int speechTherapistId)
        {
           return await 
                generalDBContext
                .TblDifficultyLevels
                    .Where(l => l.PronunciationProblemId == problemsTypeId && l.SpeechTherapistId==speechTherapistId)
                    .ToListAsync();
        }

        public async Task<List<TblPronunciationProblemsType>> GetAllPronunciationProblemsTypes()
        {
            return await generalDBContext.TblPronunciationProblemsTypes.ToListAsync();
        }

        public async Task<List<TblWord>> GetAllWords(int levelId)
        {
            return await generalDBContext.TblWords.Where(w=>w.DifficultyLevelId==levelId).ToListAsync();
        }

        public async Task<TblDifficultyLevel> PostLevel(TblDifficultyLevel difficultyLevel)
        {
            if (levelNameIsValid(difficultyLevel.DifficultyLevel,difficultyLevel.SpeechTherapistId,difficultyLevel.PronunciationProblemId).Result)
            {
                TblDifficultyLevel d= (await generalDBContext.TblDifficultyLevels.AddAsync(difficultyLevel)).Entity;
                await generalDBContext.SaveChangesAsync(); 
                return d;
            }
            return null;
           
        }

        public async Task PostWord(TblWord word)
        {
            if (wordIsValid(word.WordText, word.DifficultyLevelId).Result)
            {
                await generalDBContext.TblWords.AddAsync(word);
                await generalDBContext.SaveChangesAsync();
            }
        }

        public async Task DeleteLevel(int levelId)
        {
            //delete all the words at the level
            TblDifficultyLevel difficultyLevel = await generalDBContext.TblDifficultyLevels.FindAsync(levelId);

            //foreach (var word in generalDBContext.TblWords)
            //{
            //    if (word.DifficultyLevelId == levelId)
            //    {
            //        DeleteWord(word.Id);
            //    }
            //}
            generalDBContext.TblDifficultyLevels.Remove(difficultyLevel);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task DeleteWord(int wordId)
        {
            
            //delete the word from the level 
            TblWord word = await generalDBContext.TblWords.FindAsync(wordId);
            if (word.WordRecording.Length > 0)
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), word.WordRecording));
            }
            generalDBContext.TblWords.Remove(word);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task<bool> PutLevel(int id, int levelName)
        {
            TblDifficultyLevel level = await generalDBContext.TblDifficultyLevels.FindAsync(id);
            var tmp = generalDBContext.Entry(level);
            if(levelNameIsValid(levelName,level.SpeechTherapistId,level.PronunciationProblemId).Result)
            {
             level.DifficultyLevel = levelName;
             tmp.CurrentValues.SetValues(level);
                await generalDBContext.SaveChangesAsync();
                return true;
            }
            
            return false;
        }  

        public async Task<bool> levelNameIsValid(int levelName,int speechTherapistId, int pronunciationProblemId)
        {
            var res = await generalDBContext.TblDifficultyLevels
                .Where(l => l.SpeechTherapistId == speechTherapistId && l.DifficultyLevel == levelName && l.PronunciationProblemId == pronunciationProblemId)
                .ToListAsync();
            if (res.Count == 0)
            {
                return true;
            }
            return false;
        }

        public async Task PutWord(TblWord tblWord)
        {
            TblWord word = await generalDBContext.TblWords.FindAsync(tblWord.Id);
            if (word == null)
            {
                return;
            }
             generalDBContext.Entry(word).CurrentValues.SetValues(tblWord);


            // generalDBContext.TblWords.Remove(word);
            await generalDBContext.SaveChangesAsync();


            //if (wordIsValid(tblWord.WordText, tblWord.DifficultyLevelId).Result)
            //{
            //await generalDBContext.TblWords.AddAsync(tblWord);
            //await generalDBContext.SaveChangesAsync();
            //}
            //else
            //{
            //    await generalDBContext.TblWords.AddAsync(word);
            //    await generalDBContext.SaveChangesAsync();
            //}

        }

        public async Task<bool> wordIsValid(string wordText, int levelId)
        {
            var res = await generalDBContext.TblWords.Include(w=>w.DifficultyLevel).Where(w => w.WordText == wordText && w.DifficultyLevelId == levelId).ToListAsync();
            if (res.Count == 0)
            {
                return true;
            }
            return false;
        }

        public async Task<string> getLocalRecordPath(int word_id)
        {
            var word = await generalDBContext.TblWords.FindAsync(word_id);
            //var words = await generalDBContext.TblWords.Where(w=>w.WordText==wordText).ToListAsync();
            if (word!=null)
            {
                string path = word.WordRecording;
                return path;
            }
            return null;
        }
    }
}
