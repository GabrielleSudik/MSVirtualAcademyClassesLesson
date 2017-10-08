using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSVirtualAcademyClassesLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(); 
            myCar.Make = "Oldsmobile"; //in real life, you'd get them from somewhere
            myCar.Model = "Cutlass";
            myCar.Year = 1986;
            myCar.Color = "silver";

            Car myOtherCar;
            myOtherCar = myCar; //this copies the address of myCar.
                                //it will copy myCar's values in memory too.

            Console.WriteLine($"{myCar.Make} {myCar.Model} {myCar.Year} {myCar.Color}");

            Console.WriteLine($"{myOtherCar.Make} {myOtherCar.Model} {myOtherCar.Year} {myOtherCar.Color}");
                //those last two printed the same. makes sense.

            myOtherCar.Model = "98";

            Console.WriteLine($"{myCar.Make} {myCar.Model} {myCar.Year} {myCar.Color}");
            //this does not make sense: changing a myOtherCar value changes the myCar value. Hmm.
            //Bob Tabor says its because both instances point to the same place,
            //so I guess a change to one changes the other, because their "source" (my word)
            //is the same

            //his analogy is a bucket: myCar and myOtherCar
            //are two different handles, bringing along the same stuff in the bucket.

            //myOtherCar = null; //this instruction removes myOtherCar's handle to the bucket.

            //Console.WriteLine($"{myOtherCar.Make} {myOtherCar.Model} {myOtherCar.Year} {myOtherCar.Color}");
            //oops! that will give an exception report, because myOtherCar doesn't point to any memory
            //(ie, its bucket handle is gone)

            //myCar = null;
            //with this line, nothing is pointing at the bucket anymore.
            //eventually, .NET framework will remove the object from memory.
            //there are ways to do that manually, but it's advanced.

            Car myCar2 = new Car();

            Console.WriteLine(myCar2.Make);

            decimal value = DetermineMarketValue(myCar); //calls the returned value from the method in the Program class
            Console.WriteLine(value);

            Console.WriteLine(  myCar.DetermineMarketValue2()); //calls the method found in the Car class

            Car myCar3 = new Car("chevy", "nova", 1980, "silver");
            //and that populates the overloaded Car constructor [below]

            Console.WriteLine(DateTime.Now);

            Car.MyMethod(); //note how you called this...
                //didn't need to use an instance of Car. just Car.
                //I think it's because the method doesn't depend on a specific instance to run
                //ie, it's a general method. 
                //there's a difference between static members of a class
                //and instanced members of a class

            Console.ReadLine();
        }

        private static decimal DetermineMarketValue(Car car) //this is new -- it accepts a class as the input parameter
        {
            decimal carValue = 100.00m;
            return carValue; //this sends the value back to wherever you call it from
        }
    }

    class Car  
    {
        //properties:

        public string Make { get; set; }  
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public decimal DetermineMarketValue2()
        {
            decimal carValue;

            if (Year > 1990)  //omg! no squigglies needed?
                carValue = 5000.01m;
            else
                carValue = 2000.01m;

            return carValue;
        }

        //constructors:
        //these are methods that execute code the moment a new class is created
        //in the Car myCar = new Car(); line...
        //the () calls the constructor.

        public Car()
        {
            Make = "Nissan";

            //these can be loaded from other places like
            //config files, databases, etc.
        }

        //here's an overloaded constructor

        public Car(string make, string model, int year, string color)
        {
            Make = make;
            this.Model = model;
            Year = year;
            Color = color;
        }

        public static void MyMethod()
        {
            Console.WriteLine("Called the static MyMethod.");
        }
    }
}
