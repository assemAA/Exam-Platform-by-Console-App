using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPlatform
{
    abstract class Exam
    {
        public QuestionList questionslist;

        public double Timer { get; set; }

        public int numberOfQusetions { get; set; }
        public Exam (QuestionList questionslist, double timer)
        {
            this.questionslist = questionslist;
            Timer = timer;
            this.numberOfQusetions= questionslist.Count;
        }

        public abstract void correctExam(Dictionary<Question , Answer> examCorrector , Student student);

        public abstract void startExam(Dictionary<Question, Answer> examCorrector, Student student);
        

    }
}
