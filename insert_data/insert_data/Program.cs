using Cassandra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insert_data
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadJson();
            Console.ReadKey();

        }
        static void ReadJson()
        {
            int count = 0;
            List<Reuters_Item> objects = new List<Reuters_Item>();
            String[] lines = File.ReadAllLines(@"C:\Users\Abdel\Desktop\ESILV_S8\nosql\database\reuters.json");
            foreach (string line in lines)
            {
                count++;
                if (count % 2 == 0)
                {
                    Reuters_Item items = JsonConvert.DeserializeObject<Reuters_Item>(line);
                    Console.WriteLine(items);
                }
            }
        }

        static void InsertValue()
        {
            string keyspace = "school";
            string localhost = "127.0.0.1";
            Cluster cluster = Cluster.Builder().AddContactPoint(localhost).Build();
            ISession session = cluster.Connect(keyspace);
            session.Execute("INSERT INTO Lesson(idLesson, Title, Responsible, Level, Quota, Coeff) VALUES(10, 'Introduction to ABDELLAH', 1, 'M1', 30, 3);");
        }
    }
}
