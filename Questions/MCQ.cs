using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPlatform
{
    class MCQ : Question
    {
        public List<ChoiceAnswer> choiceAnswers ;

        public MCQ (int id , string title , int mark , Answer correctAnswer , List<ChoiceAnswer> choiceAnswers ):base(id, title, mark, correctAnswer)
        {
            this.choiceAnswers = choiceAnswers ;
        }
        public override void show()
        {
            Console.WriteLine($"{this.title}"); 
            foreach(ChoiceAnswer answer in choiceAnswers )
                Console.WriteLine(answer.ToString());
        }

        public override int GetHashCode()
        {
            return this.id;
        }
    }
}
