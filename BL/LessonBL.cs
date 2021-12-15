using DL;
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
    }
}
