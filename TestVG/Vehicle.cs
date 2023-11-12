using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
     abstract class Vehicle
       {
        protected string Color;
        protected Random rng; 
        public string LicensePlate { get; }
        public double Price { get; set; }

        public Vehicle()
        {
            rng = new Random();
            Price = 0;
            LicensePlate = randomizeLicenseNr();
            Color = generateRandomColor();
        }

        private string randomizeLicenseNr()
        {
            string licenseNr = "";

            for (int i = 0; i < 3; i++)
            {
                int letter = rng.Next(0, 26);
                licenseNr += ((char)('a' + letter));
            }

            for (int i = 0; i < 3; i++)
            {
                licenseNr += rng.Next(10);
            }

            return licenseNr.ToUpper();
        }

        private string generateRandomColor()
        {
            string[] colors = { "Röd", "Blå", "Grön", "Gul", "Svart", "Vit" };
            return colors[rng.Next(colors.Length)];
        }

        public virtual string VehicleInfo()
        {
            return "";
        }

        public void InvoiceUpdate()
        {
            Price += 1.5;
        }

    }

}
