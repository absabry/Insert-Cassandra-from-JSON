# Insert-Cassandra-from-JSON
An algorithme to insert data from json file to cassandra database, using C# language, en utilisant les libraires Newtonsoft.Json et Cassandra.


Add references : 
- *Outils ->Gérer les packages Nuget -> Console* 
  PM > Install-Package CassandraCSharpDriver
- *Outils ->Gérer les packages Nuget -> Gérer les packages Nuget pour la solution* 
  PM > Install-Package CassandraCSharpDriver
  
 `CREATE KEYSPACE IF NOT EXISTS reuters  WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor': 3 };
CREATE TYPE Texte(dateline VARCHAR, title VARCHAR, body VARCHAR);
CREATE TABLE Article (id INT PRIMARY KEY, date VARCHAR, places VARCHAR, companies VARCHAR, 
topics VARCHAR, exchanges VARCHAR,orgs VARCHAR, textes frozen<Texte>, people VARCHAR
);`

