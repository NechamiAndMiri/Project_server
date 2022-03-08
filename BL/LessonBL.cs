
using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LessonBL : ILessonBL
    {
        ILessonDL lessonDL;

        public LessonBL(ILessonDL lessonDL)
        {
            this.lessonDL = lessonDL;
        }

        public async Task<List<TblLesson>> GetAllLessons(int patientID)
        {
            List<TblLesson> lessons= await lessonDL.GetAllLessons(patientID);
            //foreach (var lesson in lessons)
            //{
            //    int sum = 0;
            //    int count = 0;
                
            //    foreach (var word in lesson.TblWordsGivenToPractices)
            //    {

            //        if (word.Score != null)
            //        {
            //            sum += word.Score.Value;
            //            count++;
            //        }
            //    }
            //    lesson.WeightedScore = sum / count;

            //}
            return lessons;
        }

        public async Task<List<TblWordsGivenToPractice>> GetLessonWords(int lessonID)
        {
            return await lessonDL.GetLessonWords(lessonID);
        }

        public async Task PostLesson(TblLesson tblLesson)
        {
            await lessonDL.PostLesson(tblLesson);
        }

        public async Task PostWordToLesson(TblWordsGivenToPractice WordGivenToPractice)
        {
            await lessonDL.PostWordToLesson(WordGivenToPractice);
        }

        public async Task PutLesson(TblLesson tblLesson)
        {
            await lessonDL.PutLesson(tblLesson);
        }

        public async Task PutWordForLesson(TblWordsGivenToPractice word)
        {
            await lessonDL.PutWordForLesson(word);
        }

        public async Task PutColIsCheckedAtLesson(int lessonId)
        {
            await lessonDL.PutColIsCheckedAtLesson(lessonId);
        }

        public async Task PutColIsValidAtWordToPractice(int wordId)
        {
            await lessonDL.PutColIsValidAtWordToPractice(wordId);
        }
         public async Task PutWordRecording(TblWordsGivenToPractice word, string filePath)
        {
            await lessonDL.PutWordRecording(word, filePath);
        }
        public async Task DeleteLesson(int lessonId)
        {
            await lessonDL.DeleteLesson(lessonId);
        }

        public async Task DeleteWordFromLesson(int wordId)
        {
            await lessonDL.DeleteWordFromLesson(wordId);
        }

       
    }
}

