using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CiSharp
{
    static public class WorkFiles
    {
        public static void ToFile(Car obj)
        {
            string myCarObj = JsonConvert.SerializeObject(obj);

            Console.WriteLine(myCarObj);

            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/file.json", myCarObj);
        }
        public static Car FromFile(string path) 
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Car>(json); 
        }

        public static void ToFileColl(List<Car> cars)
        {
            string myCarObj = JsonConvert.SerializeObject(cars);

            Console.WriteLine(myCarObj);

            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/CollectionsOfCars.json", myCarObj);

        
        }

        public static List<Car> FromFileColl(string path)
        {
            string json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<Car>>(json);
        }

    }
}
