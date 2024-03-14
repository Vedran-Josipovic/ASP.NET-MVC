using System.Collections.Generic;
using System.Linq;

namespace Vjezba.Model
{
    public class Fakultet
    {
        public List<Osoba> ListOsoba { get; set; }

        public Fakultet()
        {
            ListOsoba = new List<Osoba>();
        }


        public int KolikoProfesora()
        {
            int brProfesora = 0;
            foreach (var osoba in ListOsoba)
            {
                if (osoba is Profesor) brProfesora++;
            }
            return brProfesora;
        }


        public int KolikoStudenata()
        {
            int brStudenata = 0;
            foreach (var osoba in ListOsoba)
            {
                if (osoba is Student) brStudenata++;
            }
            return brStudenata;
        }


        public Student DohvatiStudenta(string jmbag)
        {
            foreach (var osoba in ListOsoba)
            {
                if (osoba is Student student) if (student.JMBAG == jmbag) return student;
            }
            return null;
        }

        public IEnumerable<Profesor> DohvatiProfesore()
        {
            SortedSet<Profesor> sortiraniProfesori = new SortedSet<Profesor>();

            foreach (var osoba in ListOsoba)
            {
                if (osoba is Profesor profesor) sortiraniProfesori.Add(profesor);
            }
            return sortiraniProfesori;
        }



        public IEnumerable<Student> DohvatiStudente91()
        {
            return ListOsoba.OfType<Student>().Where(s => s.DatumRodjenja.Year > 1991);
        }

        public IEnumerable<Student> DohvatiStudente91NoLinq()
        {
            List<Student> studenti = new List<Student>();
            foreach (var o in ListOsoba)
            {
                if (o is Student s) if (s.DatumRodjenja.Year > 1991) studenti.Add(s);
            }
            return studenti;
        }

        public IEnumerable<Student> StudentiNeTvzD()
        {
            return ListOsoba
                .OfType<Student>()
                .Where(s => !s.JMBAG.Substring(0, 4).Equals("0246"))
                .Where(s => s.Prezime.StartsWith('D'));
        }


        public List<Student> DohvatiStudente91List()
        {
            return DohvatiStudente91().ToList();
        }


        public Student NajboljiProsjek(int god)
        {
            return ListOsoba.OfType<Student>()
                .Where(s => s.DatumRodjenja.Year == god)
                .OrderByDescending(s => s.Prosjek)
                .FirstOrDefault();
        }

        public IEnumerable<Student> StudentiGodinaOrdered(int god)
        {
            return ListOsoba
                .OfType<Student>()
                .Where(s => s.DatumRodjenja.Year == god)
                .OrderByDescending(s => s.Prosjek);
        }


        public IEnumerable<Profesor> SviProfesori(bool asc)
        {
            if (asc == true) return ListOsoba.OfType<Profesor>().OrderBy(s => s.Prezime).ThenBy(s => s.Ime);
            else return ListOsoba.OfType<Profesor>().OrderByDescending(s => s.Prezime).ThenByDescending(s => s.Ime);
        }

        public int KolikoProfesoraUZvanju(Zvanje zvanje)
        {
            return ListOsoba
                .OfType<Profesor>()
                .Where(p => p.Zvanje == zvanje)
                .Count();
        }


        public IEnumerable<Profesor> NeaktivniProfesori(int x)
        {
            return ListOsoba
                .OfType<Profesor>()
                .Where(p => (p.Zvanje == Zvanje.Predavac) | (p.Zvanje == Zvanje.VisiPredavac))
                .Where(p => p.Predmeti.Count() < x);
        }

    }
}
