using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPlatform
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int degree { get; set; }
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
            this.degree = 0;
        }

        public override string ToString()
        {
            return $"student Name :{this.Name} --- student degree {this.degree}";
        }
    }
}
