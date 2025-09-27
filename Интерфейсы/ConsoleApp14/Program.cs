using System;

public interface IAnimal
{
    string Name { get; }
    void MakeSound();
}

public class Dog : IAnimal
{
    public string Name { get; private set; }

    public Dog(string name)
    {
        Name = name;
    }

    public void MakeSound()
    {
        Console.WriteLine("Гав!");
    }
}

public class Cat : IAnimal
{
    public string Name { get; private set; }

    public Cat(string name)
    {
        Name = name;
    }

    public void MakeSound()
    {
        Console.WriteLine("Мяу!");
    }
}

public interface IShape
{
    double Area { get; }
    double Perimeter { get; }
}

public class Circle : IShape
{
    public double Radius { get; private set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area => Math.PI * Radius * Radius;

    public double Perimeter => 2 * Math.PI * Radius;
}

public class Rectangle : IShape
{
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Area => Width * Height;

    public double Perimeter => 2 * (Width + Height);
}

public class Triangle : IShape
{
    public double SideA { get; private set; }
    public double SideB { get; private set; }
    public double SideC { get; private set; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double Area
    {
        get
        {
            double s = Perimeter / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }
    }

    public double Perimeter => SideA + SideB + SideC;
}

public interface IComparable<T>
{
    int CompareTo(T other);
}

public class Student : IComparable<Student>
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public double Grade { get; private set; }

    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public int CompareTo(Student other)
    {
        return Grade.CompareTo(other.Grade);
    }
}

public class Book : IComparable<Book>
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public double Price { get; private set; }

    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public int CompareTo(Book other)
    {
        return Price.CompareTo(other.Price);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите задачу для вывода:");
        Console.WriteLine("1 - IAnimal");
        Console.WriteLine("2 - IShape");
        Console.WriteLine("3 - IComparable");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                ShowAnimals();
                break;
            case 2:
                ShowShapes();
                break;
            case 3:
                ShowComparable();
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }

    static void ShowAnimals()
    {
        IAnimal dog = new Dog("Бобик");
        IAnimal cat = new Cat("Мурка");

        Console.WriteLine($"{dog.Name} говорит:");
        dog.MakeSound();
        Console.WriteLine($"{cat.Name} говорит:");
        cat.MakeSound();
    }

    static void ShowShapes()
    {
        IShape circle = new Circle(5);
        IShape rectangle = new Rectangle(4, 6);
        IShape triangle = new Triangle(3, 4, 5);

        Console.WriteLine($"Круг: Площадь = {circle.Area:F2}, Периметр = {circle.Perimeter:F2}");
        Console.WriteLine($"Прямоугольник: Площадь = {rectangle.Area:F2}, Периметр = {rectangle.Perimeter:F2}");
        Console.WriteLine($"Треугольник: Площадь = {triangle.Area:F2}, Периметр = {triangle.Perimeter:F2}");
    }

    static void ShowComparable()
    {
        Student student1 = new Student("Алексей", 20, 4.5);
        Student student2 = new Student("Мария", 22, 3.8);

        Console.WriteLine($"{student1.Name} (Оценка: {student1.Grade})");
        Console.WriteLine($"{student2.Name} (Оценка: {student2.Grade})");

        int comparisonResult = student1.CompareTo(student2);
        if (comparisonResult > 0)
        {
            Console.WriteLine($"{student1.Name} имеет более высокую оценку, чем {student2.Name}.");
        }
        else if (comparisonResult < 0)
        {
            Console.WriteLine($"{student2.Name} имеет более высокую оценку, чем {student1.Name}.");
        }
        else
        {
            Console.WriteLine($"{student1.Name} и {student2.Name} имеют одинаковую оценку.");
        }

        Book book1 = new Book("Война и мир", "Лев Толстой", 500);
        Book book2 = new Book("1984", "Джордж Оруэлл", 300);

        Console.WriteLine($"{book1.Title} (Цена: {book1.Price})");
        Console.WriteLine($"{book2.Title} (Цена: {book2.Price})");

        int bookComparisonResult = book1.CompareTo(book2);
        if (bookComparisonResult > 0)
        {
            Console.WriteLine($"{book1.Title} дороже, чем {book2.Title}.");
        }
        else if (bookComparisonResult < 0)
        {
            Console.WriteLine($"{book2.Title} дороже, чем {book1.Title}.");
        }
        else
        {
            Console.WriteLine($"{book1.Title} и {book2.Title} имеют одинаковую цену.");
        }
    }
}
