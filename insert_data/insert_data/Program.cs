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
            InsertCassandra();
            Console.ReadKey(); 
        }
        static void InsertCassandra()
        {
            int begin = 0;
            int k = 1; 
            Reuters_Item item;
            string[] lines= File.ReadAllLines(@"C:\Users\Abdel\Desktop\ESILV_S8\nosql\database\reuters.json"); 
            for (int i=begin;i<= 5000*k;i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("item number" + i);
                    try
                    {
                        item = JsonConvert.DeserializeObject<Reuters_Item>(lines[i]);
                        InsertValue(item);
                    }
                    catch  { }
                    item = null; 
                }
            }
        }

        static void InsertValue(Reuters_Item item)
        {

            string keyspace = "reuters";
            string localhost = "127.0.0.1";
            Cluster cluster = Cluster.Builder().AddContactPoint(localhost).Build();
            ISession session = cluster.Connect(keyspace);
            if (item.text.body != null) item.text.body = cleanText(item.text.body);
            if (item.text.title != null) item.text.title = cleanText(item.text.title);
            if (item.text.dateline != null) item.text.dateline = cleanText(item.text.dateline);
            if (item.date != null) item.date = cleanDate(item.date); 

            session.Execute("INSERT INTO Article (date, places, companies, topics, exchanges, id, orgs, textes, people)"
                           + "VALUES ('" + item.date + "','" + item.places + "','" + item.companies + "', '" + item.topics + "', '" + item.exchanges + "', " + item._id + ", '" + item.orgs
                           + "', {dateline:'" + item.text.dateline + "', title:'" + item.text.title + "', body:'" + item.text.body + "' }, '" + item.people + "');");
        }

        static string cleanText(string text)
        {
            return text.Replace("'", "''");
        }
        static string cleanDate(string text)
        {
            Dictionary<int, string> convertion = CreateDateDictio();
            foreach (KeyValuePair<int, string> entry in convertion)
            {
                if (text.Contains("-" + entry.Value + "-"))
                {
                    text = text.Replace(entry.Value, entry.Key.ToString()); 
                }
            }
            return Convert.ToDateTime(text).ToString("yyyy-MM-dd H:mm:ss.FFF");
        }
        static Dictionary<int,string> CreateDateDictio()
        {
            Dictionary<int, String> convert = new Dictionary<int, string>();
            convert.Add(1, "JAN"); 
            convert.Add(2, "FEB"); 
            convert.Add(3, "MAR"); 
            convert.Add(4, "APR"); 
            convert.Add(5, "MAY"); 
            convert.Add(6, "JUN"); 
            convert.Add(7, "JUL"); 
            convert.Add(8, "AUG"); 
            convert.Add(9, "SEP"); 
            convert.Add(10, "OCT"); 
            convert.Add(11, "NOV"); 
            convert.Add(12, "DEC");
            return convert; 
        }
    }
}
