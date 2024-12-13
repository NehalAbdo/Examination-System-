using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    public class Practical : Exams
    {

        public QuestionBase[] Questions { get; set; }

        public Practical(DateTime time, int numOfQuestions, Subject examSubject, QuestionBase[] questions)
        {
            Time = time;
            NumOfQuestions = numOfQuestions;
            ExamSubject = examSubject;
            Questions = questions;
        }


        public override void ShowExam()
        {
            
            Console.WriteLine("Practical Exam");
            foreach (var question in Questions)
            {
                DisplayQuestion(question);
                Console.WriteLine("");
                Console.Write("Your answer: ");

                int userAnswer;
                while (!int.TryParse(Console.ReadLine(), out userAnswer) || userAnswer < 1 ||
                       (question is MCQ && userAnswer > question.Answers.Length))
                {
                    Console.WriteLine("Invalid answer. Please enter a valid option number.");
                    Console.WriteLine("Please choose your answer :");
                }
                question.Useranswer = userAnswer - 1;
               
                Console.WriteLine("==========================");
            }
            Console.Clear();
            Console.WriteLine("Your Answers: ");
            foreach (var question in Questions)
            {
                Console.WriteLine($"{question.Body}");
                Console.WriteLine($"Correct Answer: {question.Answers[question.RightAnswer].AnswerText}");
                Console.WriteLine();
            }
            Console.WriteLine("==========================");

        }
    }
    }

