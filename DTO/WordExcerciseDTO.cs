using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WordExerciseDTO
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public int ExerciseId { get; set; }
        public string WordText { get; set; }
        public string WordRecording { get; set; }
        public int DifficultyLevelId { get; set; }
    }
}
