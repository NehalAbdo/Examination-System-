using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class MCQ : QuestionBase
    {
        public MCQ(string body, int mark, Answer[] answers, int rightanswer) : base("MCQ", body, mark, answers, rightanswer)
        {
        }
    }
}
