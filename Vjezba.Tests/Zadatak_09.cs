using System;
using Xunit;
using Vjezba.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Vjezba.Test
{
    
    public class Zadatak_09
    {
        [Fact]
        public void TestProfesoriZvanje()
        {
            Fakultet f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            var listOsoba = listProp.GetValue(f) as List<Osoba>;

            listOsoba.Add(new Profesor() { Prezime = "Anic", Ime = "Antonija", JMBG = "0202990330000", OIB = "22163222039", DatumIzbora = new DateTime(2012, 12, 30), Zvanje = Zvanje.Asistent });
            listOsoba.Add(new Profesor() { Prezime = "Anic", Ime = "Anton", JMBG = "0111991330000", OIB = "11163222039", DatumIzbora = new DateTime(2011, 6, 1), Zvanje = Zvanje.Asistent });
            listOsoba.Add(new Profesor() { Prezime = "Benic", Ime = "Anton", JMBG = "0303991330000", OIB = "33163222039", DatumIzbora = new DateTime(2011, 7, 19), Zvanje = Zvanje.Asistent });

            var rez = f.KolikoProfesoraUZvanju(Zvanje.Asistent);
            Assert.True(rez.GetType() == typeof(int), "Povratni tip je trebao biti int");
            Assert.Equal(3, rez);

            rez = f.KolikoProfesoraUZvanju(Zvanje.ProfVisokeSkole);
            Assert.Equal(0, rez);

            rez = f.KolikoProfesoraUZvanju(Zvanje.Predavac);
            Assert.Equal(0, rez);

            rez = f.KolikoProfesoraUZvanju(Zvanje.VisiPredavac);
            Assert.Equal(0, rez);
        }
    }
}
