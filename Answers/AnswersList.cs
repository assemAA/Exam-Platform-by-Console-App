using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPlatform
{
    class AnswersList : List<Answer>
    {
        public new void Add(Answer answer)
        {
            base.Add(answer);
        }
    }
}
