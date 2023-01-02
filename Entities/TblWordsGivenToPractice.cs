using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblWordsGivenToPractice
    {
     


        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("TblLesson")]
        public int LessonId { get; set; }
        [ForeignKey("Word")]
        public int WordId { get; set; }
        public string PatientRecording { get; set; }
        public int? Score { get; set; }
        public bool? IsValid { get; set; }

        [JsonIgnore]
        public virtual TblLesson Lesson { get; set; }
        [JsonIgnore]
        public virtual TblWord Word { get; set; }

    }
}
