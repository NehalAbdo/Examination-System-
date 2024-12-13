using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{

    public abstract class QuestionBase
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] Answers { get; set; }
        public int RightAnswer { get; set; }
        public int Useranswer { get; set; }

        public QuestionBase(string header, string body, int mark, Answer[] answers,int rightanswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = answers;
            RightAnswer = rightanswer;
            Useranswer =-1;
        }
    }

}
