using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Lab5 C# - Demonstration of All Classes");
Console.WriteLine("======================================");

// User class demonstration
Console.WriteLine("\n1. User Classes Demonstration");
Console.WriteLine("----------------------------");
UserClass cl = new UserClass();
cl.Name = "UserClass top-level";
Console.WriteLine($"Top-level UserClass name: {cl.Name}");

User.UserClass cl2 = new();
cl2.Name = "UserClass namespace User";
Console.WriteLine($"Namespaced UserClass name: {cl2.Name}");

// TransportHierarchy demonstration
Console.WriteLine("\n2. Transport Hierarchy Demonstration");
Console.WriteLine("----------------------------------");
Console.WriteLine("\nCreating and using TransportVehicle:");
TransportHierarchy.TransportVehicle vehicle = new TransportHierarchy.TransportVehicle("Generic Vehicle", 100, 50);
vehicle.Show();

Console.WriteLine("\nCreating and using Car:");
TransportHierarchy.Car car = new TransportHierarchy.Car("Toyota Corolla", 180, 5, "Gasoline");
car.Show();

Console.WriteLine("\nCreating and using Train:");
TransportHierarchy.Train train = new TransportHierarchy.Train("Express Train", 200, 200, 10);
train.Show();

Console.WriteLine("\nCreating and using Express:");
TransportHierarchy.Express express = new TransportHierarchy.Express("Bullet Train", 300, 150, 8, "Tokyo-Osaka");
express.Show();

// Copy constructor demonstration
Console.WriteLine("\nUsing copy constructor for Car:");
TransportHierarchy.Car carCopy = new TransportHierarchy.Car(car);
carCopy.Name = "Toyota Corolla Copy";
carCopy.Show();

// Geometry demonstration
Console.WriteLine("\n3. Geometry Classes Demonstration");
Console.WriteLine("-------------------------------");
Console.WriteLine("\nCreating and calculating Rectangle properties:");
Geometry.Rectangle rectangle = new Geometry.Rectangle(5, 10);
rectangle.Show();

Console.WriteLine("\nCreating and calculating Circle properties:");
Geometry.Circle circle = new Geometry.Circle(7);
circle.Show();

Console.WriteLine("\nCreating and calculating Triangle properties:");
Geometry.Triangle triangle = new Geometry.Triangle(3, 4, 5);
triangle.Show();

// Storing figures in a collection
Console.WriteLine("\nStoring different figures in a collection:");
List<Geometry.Figure> figures = new List<Geometry.Figure>
{
    new Geometry.Rectangle(8, 4),
    new Geometry.Circle(5),
    new Geometry.Triangle(5, 5, 5)
};

Console.WriteLine("\nIterating through the collection of figures:");
foreach (var figure in figures)
{
    figure.Show();
}

// VideoCassettes demonstration
Console.WriteLine("\n4. VideoCassettes Demonstration");
Console.WriteLine("-----------------------------");
List<VideoCassettes.VideoCassette> cassettes = new List<VideoCassettes.VideoCassette>
{
    new VideoCassettes.VideoCassette("The Shawshank Redemption", "Frank Darabont", 142, 15.99m),
    new VideoCassettes.VideoCassette("The Godfather", "Francis Ford Coppola", 175, 19.99m),
    new VideoCassettes.VideoCassette("Pulp Fiction", "Quentin Tarantino", 154, 12.99m),
    new VideoCassettes.VideoCassette("Fight Club", "David Fincher", 139, 9.99m)
};

Console.WriteLine("\nOriginal List of Video Cassettes:");
foreach (var cassette in cassettes)
{
    cassette.Show();
}

// Filter cassettes by price
decimal priceThreshold = 15.00m;
var filteredCassettes = cassettes.Where(c => c.Price <= priceThreshold).ToList();

Console.WriteLine($"\nCassettes with price below ${priceThreshold}:");
foreach (var cassette in filteredCassettes)
{
    cassette.Show();
}

// Add new cassettes
Console.WriteLine("\nAdding new cassettes to the collection:");
filteredCassettes.Add(new VideoCassettes.VideoCassette("The Matrix", "Wachowski Brothers", 136, 14.99m));
filteredCassettes.Add(new VideoCassettes.VideoCassette("Inception", "Christopher Nolan", 148, 13.99m));

Console.WriteLine("\nUpdated collection of cassettes:");
foreach (var cassette in filteredCassettes)
{
    cassette.Show();
}

Console.WriteLine("\nEnd of demonstration.");

namespace User
{
    class UserClass
    {
        public string Name { get; set; } = string.Empty; // Initialize with default value
        public UserClass()
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
    public string Name { get; set; } = string.Empty; // Initialize with default value
}

namespace TransportHierarchy
{
    public class TransportVehicle
    {
        public string Name { get; set; } = string.Empty; // Initialize with default value
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
        public string FuelType { get; set; } = string.Empty; // Initialize with default value

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
        public string Route { get; set; } = string.Empty; // Initialize with default value

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
}