using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class ExerciseBL : IExerciseBL
    {
        IExerciseDL exerciseDL;
        public ExerciseBL(IExerciseDL exerciseDL)
        {
            this.exerciseDL = exerciseDL;
        }
    }
}
