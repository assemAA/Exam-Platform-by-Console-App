using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPlatform
{
    class Answer
    {
        public string answer { get; set; }

        public Answer(string answer) {
            this.answer = answer;
        }

        public override string ToString()
        {
            return $"{this.answer}";
        }
    }
}
