
using DTO;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ILessonDL
    {
      Task<List<TblLesson>> GetAllLessons(int patientID);
      Task<List<TblWordsGivenToPractice>> GetLessonWords(int lessonID);
        Task<LessonDTO> PostLesson(TblLesson tblLesson);
      Task PostWordToLesson(TblWordsGivenToPractice WordGivenToPractice);
      Task PutColIsCheckedAtLesson(int lessonId);
      Task PutColIsValidAtWordToPractice(int wordId);
      Task DeleteLesson(int lessonId);
      Task DeleteWordFromLesson(int wordId);
      Task PutLesson(TblLesson tblLesson);
      Task PutWordForLesson(TblWordsGivenToPractice word);
        Task PutWordRecording(TblWordsGivenToPractice word, string filePath);
        Task<string> getLocalPatientRecordPath(int wordId);

        public Task DeleteAllWordsFromLesson(int lessonId);
    }
}