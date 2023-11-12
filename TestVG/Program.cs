namespace DeluxeParking
{
    using System;


    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int parkingCapacity = 15;
            ParkingLot parkingLot = new ParkingLot(parkingCapacity);


            while (true)
            {

                    Console.WriteLine("Hej, och välkommen till Carpark Deluxe!");
                    Console.WriteLine("Knappval: C = Parkera en bil, M = Parkera en motorcykel, B = Parkera en buss, R = Checka ut ett fordon");
                    Console.WriteLine("Status på parkeringsplatser:");
                    parkingLot.ShowParkedVehicles();

                    if (Console.KeyAvailable)
                    {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.KeyChar)
                    {
                        case 'c':
                            parkingLot.AddVehicle(new Car());
                            break;
                        case 'm':
                            parkingLot.AddVehicle(new Motorcycle());
                            break;
                        case 'b':
                            parkingLot.AddVehicle(new Bus());
                            break;
                        case 'r':
                            Console.WriteLine("Vänligen ange registreringsnumret för fordonet du önskar att checka ut.");
                            input = Console.ReadLine();
                            if (input.Length != 6)
                            {
                                Console.WriteLine("Du har angett ett felaktigt format, vänligen försök igen.");
                                if (ParkingLot.hasSpecialChar(input))
                                {
                                    Console.WriteLine("Notera att specialtecken inte är giltiga som inmatning.");
                                }
                                Thread.Sleep(1000);
                            }
                            
                            else
                            {
                                parkingLot.RemoveVehicle(input.ToUpper());
                                Thread.Sleep(1000);
                            }
                            break;

                    }

                    
                }
                    parkingLot.UpdateVehicles();
                    Thread.Sleep(1000);
                    Console.Clear();
            }
            
        }
    }
}
