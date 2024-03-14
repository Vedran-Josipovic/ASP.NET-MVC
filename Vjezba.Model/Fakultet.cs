﻿using System.Collections.Generic;
using System.Linq;

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
                if (osoba is Profesor) brProfesora++;
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
                if (osoba is Student student) if (student.JMBAG == jmbag) return student;
            }
            return null;
        }

        public IEnumerable<Profesor> DohvatiProfesore()
        {
            SortedSet<Profesor> sortiraniProfesori = new SortedSet<Profesor>();

            foreach (var osoba in listOsoba)
            {
                if (osoba is Profesor profesor) sortiraniProfesori.Add(profesor);
            }
            return sortiraniProfesori;
        }



        public IEnumerable<Student> DohvatiStudente91()
        {
             return listOsoba.OfType<Student>().Where(s => s.DatumRodjenja.Year > 1991);
        }

        public IEnumerable<Student> DohvatiStudente91NoLinq()
        {
            List<Student> studenti = new List<Student>();
            foreach(var o in listOsoba)
            {
                if(o is Student s) if(s.DatumRodjenja.Year > 1991) studenti.Add(s);
            }
            return studenti;
        }

        public IEnumerable<Student> StudentiNeTvzD()
        {
            return listOsoba
                .OfType<Student>()
                .Where(s => !s.JMBAG.Substring(0, 4).Equals("0246"))
                .Where(s => s.Prezime.StartsWith('D'));
        }




    }
}
