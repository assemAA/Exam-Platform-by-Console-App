using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPlatform
{
    abstract class Question
    {
        public int id { get; set; }
        public string title { get; set; }
        public int mark { get; set; }
        public Answer correctAnswer { get; set; }

        public Question(int _id , string _title , int _mark , Answer correctAnswer) 
        {
            this.id = _id;
            this.title = _title;
            this.mark = _mark;
            this.correctAnswer = correctAnswer;
        }

        public abstract void show();

        public abstract override int GetHashCode(); 
    }
}
