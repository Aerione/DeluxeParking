using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Bus : Vehicle
    {
        int OnboardPassengers { get; }
        public Bus() : base()
        {
            OnboardPassengers = rng.Next(60);
        }

        public override string VehicleInfo()
        {
            string info = $"{Color} buss med registreringsnumret {LicensePlate} med {OnboardPassengers} passagerare";
            return info;
        }

    }
}
