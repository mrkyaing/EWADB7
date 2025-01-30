using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OOPDay1
{
    public class Car
    {
        public string LicenceNo;
        public string GearNo;
        public static string DisplayTime=DateTime.Now.ToString();
        public Car()
        {
            LicenceNo = "No Licence";
            GearNo = "No Gear";
        }
        //Constructor Overloading 
        public Car(string l, string g)
        {
            LicenceNo = l;
            GearNo = g;
        }

        public Car(string l)
        {
            LicenceNo = l;
            GearNo = "No gear";
        }

        public void Drive()
        {
            Console.WriteLine("Car is driving now");
        }
        //Method Overloading 
        public void PlayHorn()=>Console.WriteLine("T");

        public void PlayHorn(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine("T");
            }
        }
        public static void Stop()=>Console.WriteLine("Stop");
    }
}