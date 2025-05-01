using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Lab5 C# ");
AnyFunc();

void AnyFunc()
{
    Console.WriteLine(" Some function in top-level");
}
Console.WriteLine("Problems 1 ");
AnyFunc();
UserClass cl = new UserClass();
cl.Name = " UserClass top-level ";
User.UserClass cl2 = new();
cl2.Name = " UserClass namespace User ";

namespace User
{
    class UserClass
    {
        public string Name { get; set; }
       public  UserClass()
        {
            Name = "NoName";
        }
        UserClass(string n)
        {
            Name = n;
        }
    }
}
class UserClass
{
    public string Name { get; set; }
}

namespace TransportHierarchy
{
    public class TransportVehicle
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int Capacity { get; set; }

        public TransportVehicle()
        {
            Console.WriteLine("TransportVehicle default constructor called.");
        }

        public TransportVehicle(string name, int maxSpeed, int capacity)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            Capacity = capacity;
            Console.WriteLine("TransportVehicle parameterized constructor called.");
        }

        public TransportVehicle(TransportVehicle other)
        {
            Name = other.Name;
            MaxSpeed = other.MaxSpeed;
            Capacity = other.Capacity;
            Console.WriteLine("TransportVehicle copy constructor called.");
        }

        ~TransportVehicle()
        {
            Console.WriteLine("TransportVehicle destructor called.");
        }

        public virtual void Show()
        {
            Console.WriteLine($"Transport Vehicle: {Name}, Max Speed: {MaxSpeed} km/h, Capacity: {Capacity}");
        }
    }

    public class Car : TransportVehicle
    {
        public string FuelType { get; set; }

        public Car() : base()
        {
            Console.WriteLine("Car default constructor called.");
        }

        public Car(string name, int maxSpeed, int capacity, string fuelType)
            : base(name, maxSpeed, capacity)
        {
            FuelType = fuelType;
            Console.WriteLine("Car parameterized constructor called.");
        }

        public Car(Car other) : base(other)
        {
            FuelType = other.FuelType;
            Console.WriteLine("Car copy constructor called.");
        }

        ~Car()
        {
            Console.WriteLine("Car destructor called.");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Fuel Type: {FuelType}");
        }
    }

    public class Train : TransportVehicle
    {
        public int NumberOfCarriages { get; set; }

        public Train() : base()
        {
            Console.WriteLine("Train default constructor called.");
        }

        public Train(string name, int maxSpeed, int capacity, int numberOfCarriages)
            : base(name, maxSpeed, capacity)
        {
            NumberOfCarriages = numberOfCarriages;
            Console.WriteLine("Train parameterized constructor called.");
        }

        public Train(Train other) : base(other)
        {
            NumberOfCarriages = other.NumberOfCarriages;
            Console.WriteLine("Train copy constructor called.");
        }

        ~Train()
        {
            Console.WriteLine("Train destructor called.");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Number of Carriages: {NumberOfCarriages}");
        }
    }

    public class Express : Train
    {
        public string Route { get; set; }

        public Express() : base()
        {
            Console.WriteLine("Express default constructor called.");
        }

        public Express(string name, int maxSpeed, int capacity, int numberOfCarriages, string route)
            : base(name, maxSpeed, capacity, numberOfCarriages)
        {
            Route = route;
            Console.WriteLine("Express parameterized constructor called.");
        }

        public Express(Express other) : base(other)
        {
            Route = other.Route;
            Console.WriteLine("Express copy constructor called.");
        }

        ~Express()
        {
            Console.WriteLine("Express destructor called.");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Route: {Route}");
        }
    }
}

namespace Geometry
{
    public abstract class Figure
    {
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();

        public virtual void Show()
        {
            Console.WriteLine($"Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}");
        }
    }

    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public override void Show()
        {
            Console.WriteLine("Rectangle:");
            base.Show();
        }
    }

    public class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override void Show()
        {
            Console.WriteLine("Circle:");
            base.Show();
        }
    }

    public class Triangle : Figure
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double CalculateArea()
        {
            double s = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override void Show()
        {
            Console.WriteLine("Triangle:");
            base.Show();
        }
    }
}

namespace VideoCassettes
{
    public struct VideoCassette
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }

        public VideoCassette(string title, string director, int duration, decimal price)
        {
            Title = title;
            Director = director;
            Duration = duration;
            Price = price;
        }

        public void Show()
        {
            Console.WriteLine($"Title: {Title}, Director: {Director}, Duration: {Duration} mins, Price: {Price:C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<VideoCassette> cassettes = new List<VideoCassette>
            {
                new VideoCassette("Movie A", "Director A", 120, 15.99m),
                new VideoCassette("Movie B", "Director B", 90, 9.99m),
                new VideoCassette("Movie C", "Director C", 150, 19.99m),
                new VideoCassette("Movie D", "Director D", 110, 5.99m)
            };

            Console.WriteLine("Original List of Video Cassettes:");
            foreach (var cassette in cassettes)
            {
                cassette.Show();
            }

            decimal priceThreshold = 10.00m;
            cassettes = cassettes.Where(c => c.Price <= priceThreshold).ToList();

            Console.WriteLine("\nAfter Removing Cassettes with Price Above $10:");
            foreach (var cassette in cassettes)
            {
                cassette.Show();
            }

            cassettes.Add(new VideoCassette("Movie E", "Director E", 100, 7.99m));
            cassettes.Add(new VideoCassette("Movie F", "Director F", 130, 8.99m));
            cassettes.Add(new VideoCassette("Movie G", "Director G", 140, 6.99m));

            Console.WriteLine("\nAfter Adding 3 New Cassettes:");
            foreach (var cassette in cassettes)
            {
                cassette.Show();
            }
        }
    }
}