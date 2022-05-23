using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DTO;

namespace Project_server
{
    class AutoMapping : Profile
    {
        public AutoMapping()
        {
           CreateMap<TblMessage, MessageDTO>().ForMember(dest => dest.FirstName,
                       opts => opts.MapFrom(src => src.Patient.User.FirstName))
                       .ForMember(dest => dest.LastName,
                       opts => opts.MapFrom(src => src.Patient.User.LastName))
                       .ForMember(dest=>dest.Email,
                        opts => opts.MapFrom(src => src.Patient.User.Email)).ReverseMap();
          
            CreateMap<TblWordsPerExercise, WordExerciseDTO>()
                .ForMember(dest => dest.WordText,
                opts => opts.MapFrom(src => src.Word.WordText))
                .ForMember(dest => dest.WordRecording,
                opts => opts.MapFrom(src => src.Word.WordRecording))
                .ForMember(dest => dest.DifficultyLevelId,
                opts => opts.MapFrom(src => src.Word.DifficultyLevelId)).ReverseMap();

            CreateMap<TblLesson, LessonDTO>()
          .ForMember(dest => dest.DifficultyLevelName,
                opts => opts.MapFrom(src => src.DifficultyLevel.DifficultyLevel))
           .ForMember(dest => dest.DifficultyLevelId,
                opts => opts.MapFrom(src => src.DifficultyLevel.Id))
                .ForMember(dest => dest.PronunciationProblemName,
                opts => opts.MapFrom(src => src.DifficultyLevel.PronunciationProblem.ProblemName)).ReverseMap();

            CreateMap<TblWordsGivenToPractice, WordsGivenToPracticeDTO>()
                .ForMember(dest=>dest.WordText,
                opts=>opts.MapFrom(src=>src.Word.WordText))
                .ForMember(dest => dest.WordId,
                opts => opts.MapFrom(src => src.Word.Id))
                .ForMember(dest => dest.WordRecording,
                opts => opts.MapFrom(src => src.Word.WordRecording)).ReverseMap();

            //CreateMap<TblUser, PatientDTO>().ReverseMap();
            //CreateMap<TblPatient, PatientDTO>().ReverseMap();

            //CreateMap<TblUser, SpeechTherapistDTO>().ReverseMap();
            //CreateMap<TblSpeechTherapist, SpeechTherapistDTO>().ReverseMap();


        }
    }
}
