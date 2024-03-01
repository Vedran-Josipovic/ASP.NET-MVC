﻿using System;
using Xunit;
using Vjezba.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Vjezba.Test
{
    
    public class Zadatak_11
    {
        [Fact]
        public void TestProfesoriNeaktivni()
        {
            Fakultet f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            var listOsoba = listProp.GetValue(f) as List<Osoba>;

            listOsoba.Add(new Profesor()
            {
                Prezime = "Anic",
                Ime = "Antonija",
                JMBG = "0202990330000",
                OIB = "22163222039",
                DatumIzbora = new DateTime(2012, 12, 30),
                Zvanje = Zvanje.Predavac,
                Predmeti = new List<Predmet>() { new Predmet(){ Naziv = "Matematika 1" } }
            });
            listOsoba.Add(new Profesor()
            {
                Prezime = "Anic",
                Ime = "Anton",
                JMBG = "0111991330000",
                OIB = "11163222039",
                DatumIzbora = new DateTime(2011, 6, 1),
                Zvanje = Zvanje.Asistent,
                Predmeti = new List<Predmet>() { new Predmet() { Naziv = "Matematika 1" }, new Predmet() { Naziv = "Matematika 2" }, new Predmet() { Naziv = "Matematika 3" } }
            });
            listOsoba.Add(new Profesor()
            {
                Prezime = "Benic",
                Ime = "Anton",
                JMBG = "0303991330000",
                OIB = "33163222039",
                DatumIzbora = new DateTime(2011, 7, 19),
                Zvanje = Zvanje.VisiPredavac,
                Predmeti = new List<Predmet>() { new Predmet() { Naziv = "Matematika 1" }, new Predmet() { Naziv = "Matematika 2" } }
            });

            var rez = f.NeaktivniProfesori(2);
            Assert.True(rez is IEnumerable<Profesor>, "Povratni tip je trebao biti IEnumerable<Profesor>");
            Assert.Single(rez);
            Assert.Equal("0202990330000", rez.First().JMBG);
        }
    }
}
