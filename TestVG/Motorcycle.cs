using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    class Motorcycle : Vehicle
    {
        public string Brand { get; }
        public Motorcycle ParkedNext { get; set; }
        public Motorcycle() : base()
        {
            string[] brands = { "Honda", "Suzuki", "Mazda", "Kawasaki", "Yamaha" };
            Brand = brands[rng.Next(brands.Length)];

        }

        public override string VehicleInfo()
        {
            string info = $"{Color} motorcykel med registreringsnumret {LicensePlate} av märket {Brand}";
            return info;
        }

    }
}
