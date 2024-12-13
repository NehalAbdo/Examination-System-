using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public abstract class Exams
    {
        public DateTime Time { get; set; }
        public int NumOfQuestions { get; set; }
        public Subject ExamSubject { get; set; }
        public void DisplayQuestion(QuestionBase question)
        {
            Console.WriteLine($"{question.Header}");
            Console.WriteLine($"{question.Body}     Mark({question.Mark})");

            if (question is TFQuestion)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("1. True");
                Console.WriteLine("2. False");
            }
            else if (question is MCQ)
            {
                Console.WriteLine("Options:");
                for (int i = 0; i < question.Answers.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Answers[i].AnswerText}");
                }
            }
            Console.WriteLine("");
        }
        public abstract void ShowExam( );

    }
}