using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class Final : Exams
    {
        public QuestionBase[] Questions;


        public Final(DateTime time, int numOfQuestions, Subject examSubject, QuestionBase[] questions)
        {
            Time = time;
            NumOfQuestions = numOfQuestions;
            ExamSubject = examSubject;
            Questions = questions;
        }
        public override void ShowExam()
        {
            int totalMarks = 0;
            int maxMarks = 0;
            foreach (var question in Questions)
            {
                DisplayQuestion(question);
                Console.WriteLine("");
                Console.Write("Your answer: ");

                int userAnswer;
                while (!int.TryParse(Console.ReadLine(), out userAnswer) || userAnswer < 1 ||
                       (question is TFQuestion && userAnswer > 2) ||
                       (question is MCQ && userAnswer > question.Answers.Length))
                {
                    Console.WriteLine("Invalid answer. Please enter a valid option number.");
                    Console.WriteLine("Please choose your answer (Enter the corresponding number):");
                }
                question.Useranswer = userAnswer - 1;
                if (question.Useranswer == question.RightAnswer)
                {
                    totalMarks += question.Mark;
                }
                Console.WriteLine("==========================");

            }
                Console.Clear();
            Console.WriteLine("Your Answers: ");
            foreach (var question in Questions)
            {
                DisplayQuestion(question);
                maxMarks += question.Mark;

                if (question.Useranswer != -1)
                {
                    if (question is TFQuestion)
                    {
                        Console.Write($"User's Answer: {(question.Useranswer == 0 ? "True" : "False")}");
                    }
                    else if (question is MCQ)
                    {
                        Console.Write($"User's Answer: {question.Answers[question.Useranswer].AnswerText}");
                    }
                }
                else
                {
                    Console.WriteLine("User did not answer this question.");
                }

            }
            Console.WriteLine("==========================");

            Console.WriteLine($"Grade is {totalMarks} out of {maxMarks}");

        }
    }
    }
