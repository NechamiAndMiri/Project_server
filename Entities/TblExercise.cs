using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblExercise
    {
        public TblExercise()
        {
            TblWordsPerExercises = new HashSet<TblWordsPerExercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DifficultyLevelId { get; set; }
        [JsonIgnore]
        public virtual TblDifficultyLevel DifficultyLevel { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblWordsPerExercise> TblWordsPerExercises { get; set; }
    }
}
