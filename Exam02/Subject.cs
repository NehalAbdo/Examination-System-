using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class Subject
    {
        public int SubjectId {  get; set; }
        public string SubjectName { get; set; }
        public Exams ExamSub { get; set; }

        public Subject(int subjectid,string subjectname  ) 
        {
            SubjectId = subjectid;
            SubjectName = subjectname;

        }

        public void CreateExam() 
        {
            Console.Write("Please Enter The Type Of Exam You Want To Create (1 for Practical ,2 for Final):");
            int examtype;
            while (!int.TryParse(Console.ReadLine(), out examtype) || (examtype != 1 && examtype != 2))
            {
                Console.WriteLine("Invalid input. Please enter 1 for Practical or 2 for Final.");
            }
            string extype = examtype == 1 ? "Practical" : "Final";

            Console.Write("Please Enter The Time Of Exam In Minutes:");
            int time;
            while (!int.TryParse(Console.ReadLine(), out time) || time <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer value for time.");
            }

            Console.Write("Please Enter The Number Of Questions You Wanted To Create :");
            int NumOfQuestions;
            while (!int.TryParse(Console.ReadLine(), out NumOfQuestions) || NumOfQuestions <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer value for number of questions.");
            }

            Console.Clear();

            QuestionBase[] question = new QuestionBase[NumOfQuestions];
            for (int i = 0; i < NumOfQuestions; i++) 
            {
                int questiontype;
                if (examtype == 1)
                {
                    questiontype = 2;
                }
                else
                {
                    Console.Write($"Please Choose The Types of Question Number{i + 1} (1 For True Or False || 2 For MCQ ):");
                    while (!int.TryParse(Console.ReadLine(), out questiontype) || (questiontype != 1 && questiontype != 2))
                    {
                        Console.WriteLine("Invalid input. Please enter 1 for True/False or 2 for MCQ.");
                    }
                }
                string Qtype = questiontype == 1 ? "True | False Question " : " Choose One Answer Question ";

                Console.Clear();

                Console.WriteLine(Qtype);

                Console.WriteLine("Please Enter The Body Of Question:");
                string Body = Console.ReadLine();

                Console.WriteLine("Please Enter The Marks Of The Question :");
                int Mark;
                while (!int.TryParse(Console.ReadLine(), out Mark) || Mark <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer value for marks.");
                }

                Answer[] Answers;
                int RightAnswer ;

                if (questiontype == 2)
                {
                    Answers = new Answer[] { new Answer(1, ""), new Answer(2, ""), new Answer(3, "") };
                    for (int j = 0; j < Answers.Length; j++)
                    {
                        Console.Write($"Please Enter The Choice Number {j + 1}:");
                        Answers[j].AnswerText = Console.ReadLine();
                    }
                    Console.WriteLine("Please Specify The Right Choice Of Question :");
                    while (!int.TryParse(Console.ReadLine(), out RightAnswer) || RightAnswer < 1 || RightAnswer > 3)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid choice number.");
                    }
                    RightAnswer--;

                }
                else 
                {
                    Answers = new Answer[2];
                    Console.Write($"Please Enter The Answer Of The Question (1 For True and 2 for False):");
                    while (!int.TryParse(Console.ReadLine(), out RightAnswer) || (RightAnswer != 1 && RightAnswer != 2))
                    {
                        Console.WriteLine("Invalid input. Please enter 1 for True or 2 for False.");
                    }

                }
                Console.Clear(); 
                if (questiontype == 2)
                {
                    question[i] = new MCQ(Body, Mark, Answers, RightAnswer);
                }
                else if (questiontype == 1)
                {
                    question[i] = new TFQuestion(Body, Mark, Answers, RightAnswer);
                }

            }

            Exams exams ;

            if(examtype==1)
            {
                exams = new Practical(DateTime.Now, NumOfQuestions, this, question);  
            }
            else 
            {
                exams = new Final(DateTime.Now,NumOfQuestions, this, question);
            }
            ExamSub = exams;

        }

    }
}
