using System;

// Vježba na predavanju
namespace Vjezba.Model
{
    public class Shape
    {
        //Polje (Field) - Članska varijable
        public int BorderWidth;

        //Property - Bolja članska varijabla koja automatski radi gettere i settere
        public string Color { get; private set; }

        //Konstruktor
        public Shape(string color)
        {
            Color = color;
        }

        // Ako napišemo virtual, to znači da se funkcija može overrideati
        public virtual void Print(string color)
        {
            Console.WriteLine("Shape - Color: " + Color);
        }
    }

    public class Polygon : Shape
    {
        public Polygon(string color) : base(color)
        {
        }

        public int NumberOfSides { get; set; }

        // Overrideanje gornje funkcije
        public override void Print(string color)
        {
            base.Print(color);
            Console.WriteLine("Polygon - Number of sides: " + NumberOfSides);
        }
    }

}
