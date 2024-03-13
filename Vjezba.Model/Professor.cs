using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class Professor : Osoba
    {
        public string Odjel { get; set; }
        public Zvanje Zvanje { get; set; }
        public DateTime DatumIzbora { get; set; }

        public Professor()
        {
        }

        public Professor(string odjel, Zvanje zvanje, DateTime datumIzbora)
        {
            Odjel = odjel;
            Zvanje = zvanje;
            DatumIzbora = datumIzbora;
        }





        public int KolikoDoReizbora()
        {
            DateTime reIzbor = DatumIzbora.AddYears((Zvanje == Zvanje.Asistent ? 4 : 5));
            return reIzbor.Year - DatumIzbora.Year;
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
