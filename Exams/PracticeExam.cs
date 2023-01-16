using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPlatform
{
    class PracticeExam : Exam , IComparable<Answer> , ICloneable , IComparable<Exam>
    {
        public PracticeExam(QuestionList ql, double timer) : base(ql, timer) { }

        public int CompareTo(Answer? question, Answer? studentAnswer)
        {
            int c = 0;
            bool a = question.answer.ToString().ToLower().Contains(studentAnswer.ToString().ToLower());
            if (a == true)
                c = 1;
            return c;
        }


        public sealed override void correctExam(Dictionary<Question, Answer> examCorrector, Student student)
        {
            int mark = student.degree;
            foreach (KeyValuePair<Question, Answer> item in examCorrector)
            {

                if (CompareTo(item.Key.correctAnswer, item.Value) == 1)
                {
                    mark++;
                }
            }

            student.degree = mark;
        }

        public int CompareTo(Answer? other)
        {
            return 1;
        }

        public object Clone()
        {
            return new PracticeExam(this.questionslist , this.Timer);
        }

        public int CompareTo(Exam? other)
        {
            return this.questionslist.Count.CompareTo(other.questionslist.Count);
        }

        public override void startExam(Dictionary<Question, Answer> examCorrector, Student student)
        {
            string studentRespont;
            Answer studentQuestionAnswer;
            foreach (Question item in this.questionslist)
            {
                item.show();
                Console.WriteLine("enter the character you choice ");
                studentRespont = Console.ReadLine();
                studentQuestionAnswer = new Answer(studentRespont);
                Console.WriteLine($"the correct answer is {item.correctAnswer.ToString()}");
                examCorrector.Add(item, studentQuestionAnswer);
                Console.WriteLine("#######################");
                
            }

            
 

            this.correctExam(examCorrector, student);

            Console.WriteLine(student.ToString() + $"/{this.questionslist.Count}");
        }
    }

    
}
