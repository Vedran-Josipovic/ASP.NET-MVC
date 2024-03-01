using System;
using Xunit;
using Vjezba.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Vjezba.Test
{
    
    public class Zadatak_10
    {
        [Fact]
        public void TestPredmeti()
        {
            Profesor p = new Profesor();

            Assert.True(p.Predmeti != null, "Kod stvaranja objekta automatski inicijalizirati listu!");

            Predmet p1 = new Predmet();
            p1.ECTS = 6;
            p1.Naziv = "Matematika I";
            p1.Sifra = 9983;

            Assert.True(6 == p1.ECTS, "ECTS nisu dobro spremljeni!");
            Assert.True("Matematika I" == p1.Naziv, "Naziv nisu dobro spremljeni!");
            Assert.True(9983 == p1.Sifra, "Sifra nisu dobro spremljeni!");
        }
    }
}
