using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    class ParkingLot
    {
        private Vehicle[] slots;
        private int capacity;

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
            slots = new Vehicle[capacity];
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (isSlotAvailable(vehicle))
            {
                for (int i = 0; i < capacity; i++)
                {
                    if (vehicle is Motorcycle)
                    {
                        if (slots[i] is Motorcycle MC && MC.ParkedNext == null)
                        {
                            MC.ParkedNext = (Motorcycle)vehicle;
                            Console.WriteLine($"{vehicle.VehicleInfo()} är parkerad i plats {i + 1}");
                            return;
                        }

                    }

                    if (slots[i] == null)
                    {
                        slots[i] = vehicle;

                        if (vehicle is Bus)
                        {
                            if (i + 1 < capacity)
                            {
                                slots[i + 1] = vehicle;
                            }
                        }

                        Console.WriteLine($"{vehicle.VehicleInfo()} är parkerad i plats {i + 1}");
                        return;
                    }
                    
                }
            }
            Console.WriteLine("Det finns tyvärr inga fler platser i parkeringen för detta fordon.");
        }

        public void RemoveVehicle(string licenseNr)
        {
            
            for (int i = 0; i < capacity; i++)
            {
                if (slots[i] != null)
                {
                    
                    if (slots[i] is Motorcycle MC)
                    {
                        if (MC.ParkedNext != null)
                        {
                            if (licenseNr == MC.ParkedNext.LicensePlate)
                            {
                                Console.WriteLine($"{MC.ParkedNext.VehicleInfo()} har tagits bort från plats {i + 1} | Slutfaktura: {MC.ParkedNext.Price} kr");
                                MC.ParkedNext = null;
                                return;
                            }
                        }

                        if (licenseNr == MC.LicensePlate)
                            {
                                if (MC.ParkedNext != null)
                                {
                                    Console.WriteLine($"{slots[i].VehicleInfo()} har tagits bort från plats {i + 1} | Slutfaktura:  {MC.ParkedNext.Price} kr");
                                    slots[i] = MC.ParkedNext;
                                }
                                else
                                {
                                    Console.WriteLine($"{slots[i].VehicleInfo()} har tagits bort från plats {i + 1} | Slutfaktura: {MC.Price} kr");
                                    slots[i] = null;
                                    return;
                                }

                            }
                    }

                    if (licenseNr == slots[i].LicensePlate)
                    {

                        if (slots[i] is Bus)
                        {
                            if (i + 1 < capacity)
                            {
                                slots[i + 1] = null;
                            }
                        }
                        Console.WriteLine($"{slots[i].VehicleInfo()} har tagits bort från plats {i + 1} | Slutfaktura: {slots[i].Price} kr");
                        slots[i] = null;
                        return;

                    }
                }
                
            }
            Console.WriteLine("Fordonet med det angivna registeringsnumret kan tyvärr inte hittas i parkeringen.");
        }

        public void ShowParkedVehicles()
        {
            Console.WriteLine("Parkerade fordon:");
            for (int i = 0; i < capacity; i++)
            {
                if (slots[i] != null)
                {
                    Console.WriteLine($"Plats {i + 1}: {slots[i].VehicleInfo()} | Nuvarande faktura: {slots[i].Price} kr");

                    if (slots[i] is Motorcycle MC)
                    {
                        if (MC.ParkedNext != null)
                        {
                            Console.WriteLine($"Plats {i + 1}: {MC.ParkedNext.VehicleInfo()} | Nuvarande faktura: {slots[i].Price} kr");
                        }
                    }      
                        
                }

                else
                {
                    Console.WriteLine($"Plats {i + 1}: Tomt");
                }
            }
        }

        public void UpdateVehicles()
        {

                for (int i = 0; i < slots.Length; i++)
                {
                if (slots[i] != null)
                {
                    if (slots[i] is Motorcycle MC)
                    {
                        if (MC.ParkedNext != null)
                        {
                            MC.ParkedNext.InvoiceUpdate();
                        }
                    }

                    slots[i].InvoiceUpdate();

                    if (slots[i] is Bus)
                    {
                        i++;
                    }
                }
            }
        }

        private bool isSlotAvailable(Vehicle vehicle)
        {
            if (vehicle is Bus)
            {
                for (int i = 0; i < capacity; i++)
                {
                    if (slots[i] == null && i + 1 < capacity && slots[i + 1] == null)
                    {
                        return true;
                    }
                }
            }
            else if (vehicle is Motorcycle)
            {
                for (int i = 0; i < capacity; i++)
                {
                    if (slots[i] == null)
                    {
                        return true;
                    }
                    else if (slots[i] is Motorcycle MC)
                    {
                        if (MC.ParkedNext == null)
                        {
                            return true;
                        }
                        
                    }
                }
            }
            else
            {
                for (int i = 0; i < capacity; i++)
                {
                    if (slots[i] == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
    }
}
