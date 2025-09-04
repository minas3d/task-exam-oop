using Microsoft.Win32.SafeHandles;
using System.Security.Cryptography.X509Certificates;

namespace task_exam_oop
{
    


    internal abstract class Question
    {
        public string Body { get; set; }

        public string Answer { get; set; }
        public int Degree { get; set; }
       

        protected Question(string body, string answer, int degree)
        {
            Body = body;
            Answer = answer;
            this.Degree = degree;

        }




        public abstract bool Anserquestion(string answer);

    }
    internal class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion(string body, string answer, int degrre) : base(body, answer, degrre)
        {

        }

        public override bool Anserquestion(string answer)
        {
            return answer == Answer;

        }

    }
    internal class ChooseOneQuestion : Question
    {
        public string Chois1 { get; set; }
        public string Chois2 { get; set; }
        public string Chois3 { get; set; }
        public string Chois4 { get; set; }

        public ChooseOneQuestion(string body, string chois1, string chois2, string chois3, string chois4, string answer, int degrre) : base(body, answer, degrre)
        {
            Chois1 = chois1;
            Chois2 = chois2;
            Chois3 = chois3;
            Chois4 = chois4;
        }






        public override bool Anserquestion(string answer)
        {
            return answer == Answer;
        }

    }
    internal class MultipleChoiceQuestion : Question
    {
        public string Chois1 { get; set; }
        public string Chois2 { get; set; }
        public string Chois3 { get; set; }
        public string Chois4 { get; set; }
        public MultipleChoiceQuestion(string body, string chois1, string chois2, string chois3, string chois4, string answer, int degrre) : base(body, answer, degrre)
        {
            Chois1 = chois1;
            Chois2 = chois2;
            Chois3 = chois3;
            Chois4 = chois4;
        }


        public override bool Anserquestion(string answer)
        {
            return answer == Answer;
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> exam = new List<Question>();
            Console.WriteLine(" how many qustion ");
            int x = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < x; i++)
            {

                Console.WriteLine($"What type you need?\n1: TrueOrFalse\n2: ChooseOne\n3: MultipleChoice");
                int j = Convert.ToInt32(Console.ReadLine());

                switch (j)
                {

                    case 1:
                        Console.WriteLine("enter question");
                        string quest = Console.ReadLine();
                        Console.WriteLine(" slect \n 1 : true \n 2: false  ");
                        string ans = Console.ReadLine();
                        Console.WriteLine(" degre ");
                        int de = Convert.ToInt32(Console.ReadLine());
                        var q1 = new TrueOrFalseQuestion(quest, ans, de);
                        exam.Add(q1);
                        break;

                    case 2:
                        Console.WriteLine("enter question");
                        string queest = Console.ReadLine();

                        Console.Write($"enter sho ? 1: ");
                        string choo1 = Console.ReadLine();
                        Console.Write($"enter sho ? 2: ");
                        string choo2 = Console.ReadLine();
                        Console.Write($"enter sho ? 3: ");
                        string choo3 = Console.ReadLine();
                        Console.Write($"enter sho ? 4: ");
                        string choo4 = Console.ReadLine();

                        Console.WriteLine(" enter answer ");
                        string anns = Console.ReadLine();
                        Console.WriteLine(" degre ");
                        int dee = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ChooseOne");

                        var q2 = new ChooseOneQuestion(queest, choo1, choo2,choo3, choo4, anns, dee);
                        exam.Add(q2);
                        break;

                    case 3:
                        Console.WriteLine("enter question");
                        string quuest = Console.ReadLine();

                        Console.Write($"enter sho ? 1: ");
                        string cho1 = Console.ReadLine();
                        Console.Write($"enter sho ? 2: ");
                        string cho2 = Console.ReadLine();
                        Console.Write($"enter sho ? 3: ");
                        string cho3 = Console.ReadLine();
                        Console.Write($"enter sho ? 4: ");
                        string cho4 = Console.ReadLine();
                        Console.WriteLine(" enter answer ");
                        string anss = Console.ReadLine();
                        Console.WriteLine(" degre ");
                        int dde = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ChooseOne");
                        var q3 = new MultipleChoiceQuestion(quuest, cho1,cho2,cho3,cho4, anss, dde);
                        exam.Add(q3);
                        break;

                    default:
                        Console.WriteLine(" not found ");
                        i--;
                        break;

                }
            }
            
            Console.WriteLine("===================================start exam========================================== ");
            int grade = 0;
            string incorrect = "";
            int m = 0;
            foreach (var q in exam)
            {
              
                m++;
                Console.WriteLine($"Question {m}: {q.Body} :");
                if (q is MultipleChoiceQuestion mc)
                {
                    Console.WriteLine(" choose more than one answer (separate them with a comma ,) ");
                    Console.WriteLine($"1: {mc.Chois1}");
                    Console.WriteLine($"2: {mc.Chois2}");
                    Console.WriteLine($"3: {mc.Chois3}");
                    Console.WriteLine($"4: {mc.Chois4}");
                }
                if (q is ChooseOneQuestion ch)
                {
                    Console.WriteLine(" choose  one");
                    Console.WriteLine($"1: {ch.Chois1}");
                    Console.WriteLine($"2: {ch.Chois2}");
                    Console.WriteLine($"3: {ch.Chois3}");
                    Console.WriteLine($"4: {ch.Chois4}");
                }
                if (q is TrueOrFalseQuestion tq)
                {
                    Console.WriteLine(" choose \n 1: true \n  2: false ");

                }
               
                Console.WriteLine(" enter answer ");
                string youranswer = Console.ReadLine();
              
                if (q.Anserquestion(youranswer))
                {
                    grade += q.Degree;
                }
                else
                {
                    incorrect += q.Body + "\n";
                }

               
            }
            Console.WriteLine($"your grade is = {grade}");
            if (incorrect != "")
            {
                Console.WriteLine($" Your answer is incorrect in\n {incorrect}");
            }
        }

    }

}