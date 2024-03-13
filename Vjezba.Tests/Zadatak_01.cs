using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vjezba.Model;
using Xunit;

namespace Vjezba.Test
{
    public class Zadatak_01
    {
        [Fact]
        public void TestOsoba()
        {
            Osoba o = new Osoba();
            o.Ime = "Ante";
            o.Prezime = "Tomic";
            o.OIB = "01163822039";
            o.JMBG = "0811990330013";

            Assert.True("01163822039" == o.OIB, "OIB nije dobro spremljen");
            Assert.True("0811990330013" == o.JMBG, "JMBG nije dobro spremljen");
            Assert.True(new DateTime(1990, 11, 8) == o.DatumRodjenja, "Pogrešan datum rođenja iz JMBG-a.");
            //Commit
        }

        [Fact]
        public void TestOsobaInvalidOIB()
        {
            Osoba o = new Osoba();
            Assert.Throws<InvalidOperationException>(() => {
                o.OIB = "013822039";
            });
        }

        [Fact]
        public void TestOsobaInvalidJMBG()
        {
            Osoba o = new Osoba();
            Assert.Throws<InvalidOperationException>(() => {
                o.JMBG = "081199033001q";
            });
        }

        [Fact]
        public void TestProfesor()
        {
            var o = new Profesor();
            Assert.True(typeof(Osoba).IsAssignableFrom(typeof(Profesor)), "Profesor mora naslijediti Osobu!");

            o.JMBG = "0502980330013";
            o.Zvanje = Zvanje.Asistent;
            o.Odjel = "INRO";

            Assert.True("INRO" == o.Odjel, "Odjel nije dobro spremljen");
            Assert.True(Zvanje.Asistent == o.Zvanje, "Zvanje nije dobro");
            Assert.True("0502980330013" == o.JMBG, "JMBG nije dobro spremljen");
            Assert.True(new DateTime(1980, 2, 5) == o.DatumRodjenja, "Pogrešan datum rođenja iz JMBG-a.");
        }

        [Fact]
        public void TestProfesor_Reizbor()
        {
            var o = new Profesor();
            o.Zvanje = Zvanje.Asistent;
            o.DatumIzbora = new DateTime(DateTime.Now.Year - 3, 5, 1);

            Assert.True(new DateTime(DateTime.Now.Year - 3, 5, 1) == o.DatumIzbora, "Datum izbora nije dobro spremljen");
            Assert.True(1 == o.KolikoDoReizbora(), "Pogledati pravila reizbora. Izračunati kao broj dana do reizbora / 365.");

            o.Zvanje = Zvanje.ProfVisokeSkole;
            Assert.True(2 == o.KolikoDoReizbora(), "Pogledati pravila reizbora. Izračunati kao broj dana do reizbora / 365.");
        }

        [Fact]
        public void TestStudent()
        {
            var o = new Student();
            Assert.True(typeof(Osoba).IsAssignableFrom(typeof(Student)), "Student mora naslijediti Osobu!");

            o.JMBAG = "0246664738";
            o.Prosjek = 3.45M;
            o.BrPolozeno = 7;
            o.ECTS = 33;

            Assert.True("0246664738" == o.JMBAG, "JMBAG nije dobro spremljen");
            Assert.True(3.45M == o.Prosjek, "Prosjek nije dobro spremljen");
            Assert.True(7 == o.BrPolozeno, "BrPolozeno nije dobro spremljen");
            Assert.True(33 == o.ECTS, "ECTS nije dobro spremljen");
        }

        [Fact]
        public void TestStudentInvalidJMBAG()
        {
            var o = new Student();
            Assert.Throws<InvalidOperationException>(() => {
                o.JMBAG = "024642651";
            });
        }


        [Fact]
        public void TestFakultet()
        {
            var f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            Assert.True(listProp != null, "Potrebno je napraviti svojstvo List<Osoba>!");

            var listOsoba = listProp.GetValue(f) as List<Osoba>;
            Assert.True(listOsoba != null, "Potrebno je u konstruktoru inicijalizirati property List<Osoba>!");

            var s1 = new Student() { JMBAG = "0036426443" };
            listOsoba.Add(s1);
            var s2 = new Student() { JMBAG = "0246543998" };
            listOsoba.Add(s2);
            listOsoba.Add(new Student());
            listOsoba.Add(new Profesor());
            listOsoba.Add(new Profesor());

            Assert.True(2 == f.KolikoProfesora(), "Dodana su dva profesora u listu!");
            Assert.True(3 == f.KolikoStudenata(), "Dodana su dva studenta u listu!");

            var student1 = f.DohvatiStudenta("0036426443");
            Assert.True(student1 != null, "U fakultet je dodan student 0036426443 i morao bi biti pronadjen!");
            Assert.True(s1 == student1, "Ne bi se smjela raditi nikakva kopija podatka, nego samo spremiti student i dohvatiti kada treba!");

            var student2 = f.DohvatiStudenta("0246543998");
            Assert.True(student2 != null, "U fakultet je dodan student 0246543998 i morao bi biti pronadjen!");
            Assert.True(s2 == student2, "Ne bi se smjela raditi nikakva kopija podatka, nego samo spremiti student i dohvatiti kada treba!");

            Assert.True(f.DohvatiStudenta("0246543990") == null, "Student 0246543990 nije dodan u listu i ne bi smio biti pronadjen!");
        }
    }
}
