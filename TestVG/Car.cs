using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Car : Vehicle
    {
        public bool IsElectric { get; }
        public Car() : base()
        {
            switch (rng.Next(2))
            {
                case 0:
                    IsElectric = true;
                    break;
                case 1:
                    IsElectric = false;
                    break;
            }
        }

        public override string VehicleInfo()
        {
            string info = $"{Color} bil med registreringsnumret {LicensePlate}";
            if (IsElectric)
            {
                info += " (Elbil)";
            }
            else
            {
                info += " (Bensinbil)";
            }
            return info;
        }
    }
}
