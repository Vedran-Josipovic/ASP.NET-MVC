using System;
using Xunit;
using Vjezba.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Vjezba.Test
{
    
    public class Zadatak_13
    {
        [Fact]
        public void TestIzmjeniProfesore()
        {
            Fakultet f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            var listOsoba = listProp.GetValue(f) as List<Osoba>;

            listOsoba.Add(new Student() { JMBAG = "0246378992", Prezime = "Ticaric", JMBG = "0101991330060", Prosjek = 4.4M });
            listOsoba.Add(new Student() { JMBAG = "0024638992", Prezime = "Tokic", JMBG = "0101992330040", Prosjek = 4.22M });
            listOsoba.Add(new Student() { JMBAG = "0036378992", Prezime = "Iskra", JMBG = "3112991330220", Prosjek = 4.3M });

            listOsoba.Add(new Profesor()
            {
                Prezime = "Anic",
                Ime = "Antonija",
                JMBG = "0202990330000",
                OIB = "22163222039",
                DatumIzbora = new DateTime(2012, 12, 30),
                Zvanje = Zvanje.Asistent,
                Predmeti = new List<Predmet>() { new Predmet() { Naziv = "Matematika 1", ECTS = 10 } }
            });
            listOsoba.Add(new Profesor()
            {
                Prezime = "Anic",
                Ime = "Antonija",
                JMBG = "1302990330000",
                OIB = "22163222039",
                DatumIzbora = new DateTime(2012, 12, 30),
                Zvanje = Zvanje.Asistent,
                Predmeti = new List<Predmet>() { new Predmet() { Naziv = "Matematika 1", ECTS = 4 }, new Predmet() { Naziv = "Matematika 2", ECTS = 5 }, new Predmet() { Naziv = "Matematika 3", ECTS = 4 } }
            });
            listOsoba.Add(new Profesor()
            {
                Prezime = "Anic",
                Ime = "Anton",
                JMBG = "0111991330000",
                OIB = "11163222039",
                DatumIzbora = new DateTime(2011, 6, 1),
                Zvanje = Zvanje.Asistent,
                Predmeti = new List<Predmet>() { new Predmet() { Naziv = "Matematika 1", ECTS = 5 }, new Predmet() { Naziv = "Matematika 2", ECTS = 6 }, new Predmet() { Naziv = "Matematika 3", ECTS = 7 } }
            });
            listOsoba.Add(new Profesor()
            {
                Prezime = "Benic",
                Ime = "Anton",
                JMBG = "0303991330000",
                OIB = "33163222039",
                DatumIzbora = new DateTime(2011, 7, 19),
                Zvanje = Zvanje.VisiPredavac,
                Predmeti = new List<Predmet>() { new Predmet() { Naziv = "Matematika 1", ECTS = 5 }, new Predmet() { Naziv = "Matematika 2", ECTS = 5 } }
            });

            listOsoba.Add(new Student() { JMBAG = "0246111112", Prezime = "Medo", JMBG = "3112991330010", Prosjek = 4.5M });
            listOsoba.Add(new Profesor() { Prezime = "Benic", Ime = "Anton", JMBG = "0303991330000", OIB = "33163222039", DatumIzbora = new DateTime(2011, 7, 19) });
            listOsoba.Add(new Student() { JMBAG = "0246112232", Prezime = "Trtic", JMBG = "0506991330032", Prosjek = 4.41M });
            listOsoba.Add(new Student() { JMBAG = "0246038992", Prezime = "Antonic", JMBG = "1111992330099", Prosjek = 4.21M });

            f.IzmjeniProfesore(p => { p.Prezime = "_" + p.Prezime; });

            Assert.True(listOsoba.OfType<Profesor>().All(p => p.Prezime.StartsWith("_")), "Funkcija koja je proslijeđena dodaje _ na početku svakog prezimena!");
            Assert.False(listOsoba.OfType<Student>().Any(p => p.Prezime.StartsWith("_")), "Treba mijenjati samo profesore!");
        }
    }
}
