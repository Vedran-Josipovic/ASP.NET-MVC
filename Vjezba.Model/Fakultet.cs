using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class Fakultet
    {
        public List<Professor> Professors { get; set; }
        public List<Student> Students { get; set; }

        public Fakultet(List<Professor> professors, List<Student> students)
        {
            Professors = professors;
            Students = students;
        }
    }
}
