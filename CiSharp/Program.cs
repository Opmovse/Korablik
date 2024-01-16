using CiSharp;
using Newtonsoft.Json;

public class Program
{
    public static void Main()
    {

        Car.All = WorkFiles.FromFileColl(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/CollectionsOfCars.json");

        Console.WriteLine(Car.All.Select(x => x.Name).ToList()[1]);
    }
}

public class Car : NASA, IMovable
{

    public static List<Car> All = new List<Car>();


    public Car(string name)
    {
        this.Name = name;
        this.Id = All.Count;
    }

    public Car()
    {
        this.Id = All.Count;
        All.Add(this);

        
    }

    public void Move(int x, int y)
    {
        MyProperty = y;
        Console.WriteLine(MyProperty);
        MyProperty = 1;
        Console.WriteLine(MyProperty);
    }

    public string Name { get; set; }

    public int Id;

    private int myVar;

    public int MyProperty
    {
        get { return myVar; }

        set
        {
            if (value != 0)
            {
                throw new Exception("АШЫБКА");
            }
            else { myVar = value; }
        }
    }

}


public class NASA
{
    public int ADSAKDA;
    public int ADSsAKDA;
}
interface IMovable
{
    // константа
    // const int MinSpeed = 0;     // минимальная скорость
    // статическая переменная
    // static int MaxSpeed = 60;   // максимальная скорость
    // метод
    void Move(int x, int y);                // движение
    // свойство
    string Name { get; set; }   // название
}