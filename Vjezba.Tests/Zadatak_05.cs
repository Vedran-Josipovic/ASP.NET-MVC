﻿using System;
using Vjezba.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Xunit;

namespace Vjezba.Test
{
    public class Zadatak_05
    {
        [Fact]
        public void TestDohvati91List()
        {
            Fakultet f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            var listOsoba = listProp.GetValue(f) as List<Osoba>;

            listOsoba.Add(new Profesor() { JMBG = "0111991330000", OIB = "11163222039", DatumIzbora = new DateTime(2011, 6, 1) });
            listOsoba.Add(new Profesor() { JMBG = "0202990330000", OIB = "22163222039", DatumIzbora = new DateTime(2012, 12, 30) });
            listOsoba.Add(new Profesor() { JMBG = "0303991330000", OIB = "33163222039", DatumIzbora = new DateTime(2011, 7, 19) });

            listOsoba.Add(new Student() { JMBAG = "0246378992", Prezime = "Ticaric", JMBG = "0101991330000" });
            listOsoba.Add(new Student() { JMBAG = "0024638992", Prezime = "Tokic", JMBG = "0101992330000" });
            listOsoba.Add(new Student() { JMBAG = "0036378992", Prezime = "Iskra", JMBG = "3112990330000" });
            listOsoba.Add(new Student() { JMBAG = "0246111112", Prezime = "Medo", JMBG = "3112991330000" });
            listOsoba.Add(new Student() { JMBAG = "0246112232", Prezime = "Trtic", JMBG = "0506993330000" });

            var rez = f.DohvatiStudente91List();
            Assert.True(rez is List<Student>, "Povratni tip je trebao biti List<Student>");
            Assert.Equal(2, rez.Count());
            Assert.Contains(rez, x => x.JMBG == "0101992330000");
            Assert.Contains(rez, x => x.JMBG == "0506993330000");
        }
    }
}
