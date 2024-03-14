using System;
using System.Text.RegularExpressions;

namespace Vjezba.Model
{
    public class Student : Osoba
    {
        private string _jmbag;
        public string JMBAG
        {
            get => _jmbag;
            set
            {
                if (value.Length != 10) throw new InvalidOperationException("JMBAG Treba imati 10 brojki.");
                bool isNumeric = Regex.IsMatch(value, @"^\d+$");
                if (!isNumeric) throw new InvalidOperationException("OIB treba sadržavati samo brojke.");
                _jmbag = value;
            }
        }


        public decimal Prosjek { get; set; }

        public int BrPolozeno { get; set; }

        public int ECTS { get; set; }

        public Student(string jMBAG, decimal prosjek, int brPolozeno, int eCTS)
        {
            JMBAG = jMBAG;
            Prosjek = prosjek;
            BrPolozeno = brPolozeno;
            ECTS = eCTS;
        }

        public Student()
        {
        }
    }
}
