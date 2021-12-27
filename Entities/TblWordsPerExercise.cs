using Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblWordsPerExercise
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public int ExerciseId { get; set; }


        [JsonIgnore]
        public virtual TblExercise Exercise { get; set; }
        [JsonIgnore]
        public virtual TblWord Word { get; set; }
    }
}
