using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPlatform
{
    class TrueFalse : Question
    {
        public List<ChoiceAnswer> choices { get; set; }

        public TrueFalse(int id , string title , int mark , Answer correctAnswer ):base(id,title,mark,correctAnswer)
        {
            this.choices= new List<ChoiceAnswer>() { new ChoiceAnswer ("T") , new ChoiceAnswer("F") };
        }

        public override void show()
        {
            Console.WriteLine($"{this.title} : if True press t if false press f");
            foreach(ChoiceAnswer answer in choices )
               Console.WriteLine(answer.ToString());
        }

        public override int GetHashCode()
        {
           return this.id;
        }
    }
}
