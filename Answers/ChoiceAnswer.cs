using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPlatform
{
    class ChoiceAnswer
    {
        public string choice { get; set; }
        public ChoiceAnswer(string choice)
        {
            this.choice = choice;
        }

        public override string ToString()
        {
            return $"{this.choice}";
        }
    }
}
