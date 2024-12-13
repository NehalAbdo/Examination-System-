using System.Diagnostics;

namespace Exam02
{
    internal class Program
    {
        
        
            static void Main(string[] args)
            {
                Subject sub1 = new Subject(10, "C#");
                sub1.CreateExam();
                Console.Clear();
                Console.WriteLine("Do you want to start the exam? (y/n):");
                if (char.Parse(Console.ReadLine()) == 'y')
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    sub1.ExamSub.ShowExam();
                    Console.WriteLine($"The elapsed time = {sw.Elapsed}");
                }

            }
    }
}

