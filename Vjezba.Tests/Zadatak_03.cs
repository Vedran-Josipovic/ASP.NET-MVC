﻿using System;
using Vjezba.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Xunit;

namespace Vjezba.Test
{
    public class Zadatak_03
    {
        [Fact]
        public void DohvatiStudente91Test()
        {
            Fakultet f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            var listOsoba = listProp.GetValue(f) as List<Osoba>;

            listOsoba.Add(new Student() { JMBG = "0101991330000" });
            listOsoba.Add(new Profesor() { JMBG = "0111991330000", OIB = "11163222039", DatumIzbora = new DateTime(2011, 6, 1) });
            listOsoba.Add(new Student() { JMBG = "0101992330000" });
            listOsoba.Add(new Student() { JMBG = "3112990330000" });
            listOsoba.Add(new Profesor() { JMBG = "0202990330000", OIB = "22163222039", DatumIzbora = new DateTime(2012, 12, 30) });
            listOsoba.Add(new Profesor() { JMBG = "0303991330000", OIB = "33163222039", DatumIzbora = new DateTime(2011, 7, 19) });
            listOsoba.Add(new Student() { JMBG = "3112991330000" });

            var rez = f.DohvatiStudente91();
            Assert.True(rez is IEnumerable<Student>, "Povratni tip je trebao biti IEnumerable<Student>");
            Assert.Single(rez);
            Assert.Contains(rez, x => x.JMBG == "0101992330000");

            rez = f.DohvatiStudente91NoLinq();
            Assert.True(rez is IEnumerable<Student>, "Povratni tip je trebao biti IEnumerable<Student>");
            Assert.Single(rez);
            Assert.Contains(rez, x => x.JMBG == "0101992330000");
        }
    }
}
