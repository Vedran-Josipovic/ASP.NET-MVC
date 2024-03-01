using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vjezba.Model;
using Xunit;

namespace Vjezba.Test
{
    public class Zadatak_02
    {
        [Fact]
        public void DohvatiProfesoreTest()
        {
            Fakultet f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            var listOsoba = listProp.GetValue(f) as List<Osoba>;

            listOsoba.Add(new Student());
            listOsoba.Add(new Profesor() { OIB = "11163222039", DatumIzbora = new DateTime(2011, 6, 1) });
            listOsoba.Add(new Student());
            listOsoba.Add(new Student());
            listOsoba.Add(new Profesor() { OIB = "22163222039", DatumIzbora = new DateTime(2012, 12, 30) });
            listOsoba.Add(new Profesor() { OIB = "33163222039", DatumIzbora = new DateTime(2011, 7, 19) });

            var rez = f.DohvatiProfesore();
            Assert.True(typeof(IEnumerable<Profesor>).IsAssignableFrom(rez.GetType()), "Povratni tip je trebao biti IEnumerable<Profesor>");
            Assert.Equal(3, rez.Count());
            Assert.Equal("11163222039", rez.ElementAt(0).OIB);
            Assert.Equal("33163222039", rez.ElementAt(1).OIB);
            Assert.Equal("22163222039", rez.ElementAt(2).OIB);
        }
    }
}
