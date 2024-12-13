using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class TFQuestion : QuestionBase
    {
        public TFQuestion( string body, int mark, Answer[] answers, int rightanswer) : base("True | False", body, mark, answers, rightanswer)
        {
        }
    }
}
