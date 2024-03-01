﻿using System;
using Xunit;
using Vjezba.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Vjezba.Test
{
    
    public class Zadatak_06
    {
        [Fact]
        public void TestProsjek92()
        {
            Fakultet f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            var listOsoba = listProp.GetValue(f) as List<Osoba>;

            listOsoba.Add(new Profesor() { JMBG = "0111991330000", OIB = "11163222039", DatumIzbora = new DateTime(2011, 6, 1) });
            listOsoba.Add(new Profesor() { JMBG = "0202990330000", OIB = "22163222039", DatumIzbora = new DateTime(2012, 12, 30) });
            listOsoba.Add(new Profesor() { JMBG = "0303991330000", OIB = "33163222039", DatumIzbora = new DateTime(2011, 7, 19) });

            listOsoba.Add(new Student() { JMBAG = "0246378992", Prezime = "Ticaric", JMBG = "0101991330000", Prosjek = 4.4M });
            listOsoba.Add(new Student() { JMBAG = "0024638992", Prezime = "Tokic", JMBG = "0101992330000", Prosjek = 4.22M });
            listOsoba.Add(new Student() { JMBAG = "0036378992", Prezime = "Iskra", JMBG = "3112990330000", Prosjek = 4.3M });
            listOsoba.Add(new Student() { JMBAG = "0246111112", Prezime = "Medo", JMBG = "3112991330000", Prosjek = 4.5M });
            listOsoba.Add(new Student() { JMBAG = "0246112232", Prezime = "Trtic", JMBG = "0506993330000", Prosjek = 4.4M });
            listOsoba.Add(new Student() { JMBAG = "0246038992", Prezime = "Antonic", JMBG = "1111992330000", Prosjek = 4.21M });

            var rez = f.NajboljiProsjek(1992);
            Assert.True(rez is Student, "Povratni tip je trebao biti Student");
            Assert.Equal("0101992330000", rez.JMBG);
        }

        [Fact]
        public void TestProsjek92Samo1()
        {
            Fakultet f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            var listOsoba = listProp.GetValue(f) as List<Osoba>;

            listOsoba.Add(new Student() { JMBAG = "0024638992", Prezime = "Tokic", JMBG = "3112992330000", Prosjek = 4.22M });

            var rez = f.NajboljiProsjek(1992);
            Assert.True(rez is Student, "Povratni tip je trebao biti Student");
            Assert.Equal("3112992330000", rez.JMBG);
        }

        [Fact]
        public void TestProsjek92NitiJedan()
        {
            Fakultet f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            var listOsoba = listProp.GetValue(f) as List<Osoba>;

            listOsoba.Add(new Profesor() { JMBG = "0111991330000", OIB = "11163222039", DatumIzbora = new DateTime(2011, 6, 1) });
            listOsoba.Add(new Profesor() { JMBG = "0202990330000", OIB = "22163222039", DatumIzbora = new DateTime(2012, 12, 30) });
            listOsoba.Add(new Profesor() { JMBG = "0303991330000", OIB = "33163222039", DatumIzbora = new DateTime(2011, 7, 19) });

            listOsoba.Add(new Student() { JMBAG = "0246378992", Prezime = "Ticaric", JMBG = "0101991330000", Prosjek = 4.4M });
            listOsoba.Add(new Student() { JMBAG = "0024638992", Prezime = "Tokic", JMBG = "0101993330000", Prosjek = 4.22M });
            listOsoba.Add(new Student() { JMBAG = "0036378992", Prezime = "Iskra", JMBG = "3112990330000", Prosjek = 4.3M });
            listOsoba.Add(new Student() { JMBAG = "0246111112", Prezime = "Medo", JMBG = "3112991330000", Prosjek = 4.5M });
            listOsoba.Add(new Student() { JMBAG = "0246112232", Prezime = "Trtic", JMBG = "0506993330000", Prosjek = 4.4M });
            listOsoba.Add(new Student() { JMBAG = "0246038992", Prezime = "Antonic", JMBG = "1111998330000", Prosjek = 4.21M });

            var rez = f.NajboljiProsjek(1992);
            Assert.True(rez == null, "Ne postoji niti jedan rodjen 1992");
        }
    }
}
