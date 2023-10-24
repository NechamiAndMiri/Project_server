using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IWordDL
    {
        Task<List<TblPronunciationProblemsType>> GetAllPronunciationProblemsTypes();
        Task<List<TblDifficultyLevel>> GetAllLevels(int problemsTypeId, int speechTherapistId);
        Task<List<TblWord>> GetAllWords(int levelId);
        Task<TblWordsGivenToPractice> GetWordToPractice(int wordGivenToPracticeId);
        Task<TblDifficultyLevel> PostLevel(TblDifficultyLevel difficultyLevel);
        Task PostWord(TblWord word);
        Task DeleteLevel(int levelId);
        Task DeleteWord(int wordId);
        Task<bool> PutLevel(int id, int levelName);
        Task PutWord(TblWord tblWord);
        Task<string> getLocalRecordPath(int word_id);
    }
}