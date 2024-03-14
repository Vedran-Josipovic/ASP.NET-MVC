using System;

namespace Vjezba.Model
{
    public class Profesor : Osoba, IComparable<Profesor>
    {
        public string Odjel { get; set; }
        public Zvanje Zvanje { get; set; }
        public DateTime DatumIzbora { get; set; }

        public Profesor()
        {
        }

        public Profesor(string odjel, Zvanje zvanje, DateTime datumIzbora)
        {
            Odjel = odjel;
            Zvanje = zvanje;
            DatumIzbora = datumIzbora;
        }





        public int KolikoDoReizbora()
        {
            DateTime reIzbor = DatumIzbora.AddYears(Zvanje == Zvanje.Asistent ? 4 : 5);
            return (reIzbor - DateTime.Now).Days / 365;
        }

        public int CompareTo(Profesor other)
        {
            if (other == null) return 1;
            return this.DatumIzbora.CompareTo(other.DatumIzbora);
        }
    }

    public enum Zvanje
    {
        Asistent,
        Predavac,
        VisiPredavac,
        ProfVisokeSkole,
    }


}
