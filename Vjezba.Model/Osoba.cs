using System;
using System.Text.RegularExpressions;

namespace Vjezba.Model
{
    public class Osoba
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

        private string _oib;
        public string OIB
        {
            get => _oib;
            set
            {
                if (value.Length != 11) throw new InvalidOperationException("OIB Treba imati 11 brojki.");
                bool isNumeric = Regex.IsMatch(value, @"^\d+$");
                if (!isNumeric) throw new InvalidOperationException("OIB treba sadržavati samo brojke.");
                _oib = value;
            }
        }

        private string _jmbg;
        public string JMBG
        {
            get => _jmbg;
            set
            {
                if (value.Length != 13) throw new InvalidOperationException("JMBG Treba imati 13 brojki.");
                bool isNumeric = Regex.IsMatch(value, @"^\d+$");
                if (!isNumeric) throw new InvalidOperationException("JMBG treba sadržavati samo brojke.");
                _jmbg = value;

                DatumRodjenja = IzvuciDatumRodjenja(_jmbg);
            }
        }

        public DateTime DatumRodjenja { get; private set; }


        private DateTime IzvuciDatumRodjenja(string Jmbg)
        {
            // dd mm ggg
            string dan = Jmbg.Substring(0, 2);
            string mjesec = Jmbg.Substring(2, 2);
            string godina = Jmbg.Substring(4, 3);

            string datumRodjenja = '1' + godina + '-' + mjesec + '-' + dan;

            return DateTime.Parse(datumRodjenja);
        }

        public Osoba(string ime, string prezime, string oib, string jmbg)
        {
            Ime = ime;
            Prezime = prezime;
            OIB = oib;
            JMBG = jmbg;
        }

        public Osoba() { }



    }

}
