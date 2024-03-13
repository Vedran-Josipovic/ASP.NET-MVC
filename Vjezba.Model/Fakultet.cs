using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class Fakultet
    {
        public List<Osoba> listOsoba { get; set; }

        public Fakultet()
        {
            listOsoba = new List<Osoba>();
        }


        public int KolikoProfesora()
        {
            int brProfesora = 0;
            foreach (var osoba in listOsoba)
            {
                if (osoba is Professor) brProfesora++;
            }
            return brProfesora;
        }


        public int KolikoStudenata()
        {
            int brStudenata = 0;
            foreach (var osoba in listOsoba)
            {
                if (osoba is Student) brStudenata++;
            }
            return brStudenata;
        }


        public Student DohvatiStudenta(string jmbag) 
        {
            foreach (var osoba in listOsoba)
            {
                if (osoba is Student student) if(student.JMBAG == jmbag) return student;
            }
             return null;
        }

    }
}
