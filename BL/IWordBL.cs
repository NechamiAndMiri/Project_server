using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IWordBL
    {
        Task<List<TblPronunciationProblemsType>> GetAllPronunciationProblemsTypes();
        Task<List<TblDifficultyLevel>> GetAllLevels(int problemsTypeId, int speechTherapistId);
        Task<TblDifficultyLevel> PostLevel(TblDifficultyLevel difficultyLevel);
        public  Task PutWord(TblWord tblWord);
        public  Task<bool> PutLevel(int id, int levelName);
        public  Task DeleteWord(int wordId);
        public  Task DeleteLevel(int levelId);
        public  Task PostWord(TblWord word);
        public  Task<List<TblWord>> GetAllWords(int levelId);
        Task<string> getLocalRecordPath(int word_id);
    }
}