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
            //var abc = "hello the're";
            //abc = abc.Replace("'", "''");
            //Console.WriteLine(abc);
            Console.ReadKey();

        }
        static void ReadJson()
        {
            int count = 0;
            List<Reuters_Item> objects = new List<Reuters_Item>();
            String[] lines = File.ReadAllLines("reuters.json");
            foreach (string line in lines)
            {
                count++;
                if (count % 2 == 0)
                {
                    Reuters_Item items = JsonConvert.DeserializeObject<Reuters_Item>(line);
                    Console.WriteLine();

                     Console.WriteLine("item number" + count);
                     InsertValue(items);
                     //Console.WriteLine(items);
                }
            }
        }

        static void InsertValue(Reuters_Item item)
        {
            string keyspace = "reuters";
            string localhost = "127.0.0.1";
            Cluster cluster = Cluster.Builder().AddContactPoint(localhost).Build();
            ISession session = cluster.Connect(keyspace);
            if(item.text.body != null) item.text.body=(item.text.body).Replace("'", "''");
            if (item.text.title != null) item.text.title = (item.text.title).Replace("'", "''");
            if (item.text.dateline != null) item.text.dateline = (item.text.dateline).Replace("'", "''");

            Console.WriteLine(item.text.body);
            Console.WriteLine("********************requete *************************");
            //Console.WriteLine("INSERT INTO Article(date, places, companies, topics, exchanges, id, orgs, textes, people)  VALUES('26-FEB-1987 15:03:27.51', 'usa', '', '', '', 2, '', { dateline: 'HOUSTON, Feb 26 -', title: 'TEXAS COMMERCE BANCSHARES TCB FILES PLAN', body: 'Moody''s Investors Service Inc said it lowered the debt and preferred stock ratings of USX Corp and its units. About seven billion dlrs of securities is affected.     Moody''s said Marathon Oil Co''s recent establishment of up to one billion dlrs in production payment facilities on its prolific Yates Field has significant negative implications for USX''s unsecured creditors.     The company appears to have positioned its steel segment for a return to profit by late 1987, Moody''s added.     Ratings lowered include those on USX''s senior debt to BA-1 from BAA-3.  Reuter' }, '');");
            session.Execute("INSERT INTO Article (date, places, companies, topics, exchanges, id, orgs, textes, people)" 
                           +"VALUES ('"+ item.date +"','"+item.places+ "','" + item.companies+ "', '" + item.topics+ "', '" + item.exchanges+ "', " + item._id+ ", '" + item.orgs
                           + "', {dateline:'" + item.text.dateline + "', title:'"+item.text.title+ "', body:'"+item.text.body+ "' }, '" + item.people+ "');");
        }
    }
}
