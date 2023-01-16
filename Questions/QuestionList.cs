using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPlatform
{
    class QuestionList : List<Question>
    {
        public new void Add(Question question)
        {
            base.Add(question);
        }
    }
}
