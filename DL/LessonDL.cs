
using AutoMapper;
using DTO;
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
    public class LessonDL : ILessonDL
    {
        GeneralDBContext generalDBContext;
        IMapper mapper;
        public LessonDL(GeneralDBContext generalDBContext, IMapper mapper)
        {
            this.generalDBContext = generalDBContext;
            this.mapper = mapper;
        }

        public async Task<List<TblLesson>> GetAllLessons(int patientID)
        {
            return await generalDBContext.TblLessons.Where(l => l.PatientId == patientID).Include(l => l.DifficultyLevel).ThenInclude(d => d.PronunciationProblem).ToListAsync();//.Include(x => ((TblWordsGivenToPractice)x).Score)
        }

        public async Task<List<TblWordsGivenToPractice>> GetLessonWords(int lessonID)
        {
            return await generalDBContext.TblWordsGivenToPractices.Where(w => w.LessonId == lessonID).Include(l => l.Word).ToListAsync();
        }

        public async Task<LessonDTO> PostLesson(TblLesson tblLesson)
        {
            TblLesson lesson = (await generalDBContext.TblLessons.AddAsync(tblLesson)).Entity;
            await generalDBContext.SaveChangesAsync();
            lesson = (await generalDBContext.TblLessons.Where((l) => lesson.Id == l.Id).Include(l => l.DifficultyLevel).ThenInclude(d => d.PronunciationProblem).ToListAsync())[0];
            return mapper.Map<TblLesson, LessonDTO>(lesson);
        }

        public async Task PostWordToLesson(TblWordsGivenToPractice WordGivenToPractice)
        {

            await generalDBContext.TblWordsGivenToPractices.AddAsync(WordGivenToPractice);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task PutLesson(TblLesson tblLesson)
        {
            TblLesson lesson = await generalDBContext.TblLessons.FindAsync(tblLesson.Id);
            if (lesson == null)
            {
                return;
            }
            generalDBContext.Entry(lesson).CurrentValues.SetValues(tblLesson);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task PutWordForLesson(TblWordsGivenToPractice word)
        {
            TblWordsGivenToPractice practiceWord = await generalDBContext.TblWordsGivenToPractices.FindAsync(word.Id);
            if (practiceWord == null)
            {
                return;
            }
            generalDBContext.Entry(practiceWord).CurrentValues.SetValues(word);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task PutColIsCheckedAtLesson(int lessonId)
        {
            TblLesson lesson = await generalDBContext.TblLessons.FindAsync(lessonId);
            var x = generalDBContext.Entry(lesson);
            lesson.IsChecked = !lesson.IsChecked;
            x.CurrentValues.SetValues(lesson);
            await generalDBContext.SaveChangesAsync();
        }



        public async Task PutColIsValidAtWordToPractice(int wordId)
        {
            TblWordsGivenToPractice wordGivenToPractice = await generalDBContext.TblWordsGivenToPractices.FindAsync(wordId);
            var x = generalDBContext.Entry(wordGivenToPractice);
            wordGivenToPractice.IsValid = !wordGivenToPractice.IsValid;
            x.CurrentValues.SetValues(wordGivenToPractice);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task DeleteLesson(int lessonId)
        {
            TblLesson lesson = await generalDBContext.TblLessons.FindAsync(lessonId);
            await DeleteAllWordsFromLesson(lessonId);
            generalDBContext.TblLessons.Remove(lesson);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task DeleteAllWordsFromLesson(int lessonId)
        {
            foreach (var word in generalDBContext.TblWordsGivenToPractices)
            {
                if (word.LessonId == lessonId)
                {
                    await DeleteWordFromLesson(word.Id);
                }
            }
        }

        public async Task DeleteWordFromLesson(int wordId)
        {
            TblWordsGivenToPractice wordGivenToPractice = await generalDBContext.TblWordsGivenToPractices.FindAsync(wordId);
            generalDBContext.TblWordsGivenToPractices.Remove(wordGivenToPractice);
            await generalDBContext.SaveChangesAsync();
        }

        public async Task PutWordRecording(TblWordsGivenToPractice word, string filePath)
        {
            TblWordsGivenToPractice practiceWord = await generalDBContext.TblWordsGivenToPractices.FindAsync(word.Id);
            if (practiceWord == null)
            {
                return;
            }

            string oldRecord = practiceWord.PatientRecording;
            if (oldRecord.Length > 0)
                File.Delete(Path.Combine(Directory.GetCurrentDirectory(), oldRecord));

            var x = generalDBContext.Entry(practiceWord);
            practiceWord.PatientRecording = filePath;
            x.CurrentValues.SetValues(practiceWord);
            //word.PatientRecording = filePath;

            //generalDBContext.Entry(practiceWord).CurrentValues.SetValues(word);
            await generalDBContext.SaveChangesAsync();

        }

        public async Task<string> getLocalPatientRecordPath(int wordId)
        {
            var word = await generalDBContext.TblWordsGivenToPractices.FindAsync(wordId);
            if (word != null)
            {

                string path = word.PatientRecording;
                return path;
            }
            return null;
        }

        public async Task UpdateWordsForLesson(List<TblWordsGivenToPractice> wordsGivenToPractice)
        {
            try
            {
                if (wordsGivenToPractice.Any())
                {
                    generalDBContext.TblWordsGivenToPractices.UpdateRange(wordsGivenToPractice);

                    await generalDBContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                {
                    throw;
                }

            }
        }
    }
}

