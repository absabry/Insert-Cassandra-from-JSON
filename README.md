# Insert-Cassandra-from-JSON
An algorithme to insert data from json file to cassandra database, using Newtonsoft.Json and Cassandra libraries (C# language).


Add references : 
- *Outils ->Gérer les packages Nuget -> Console* 
  PM > Install-Package CassandraCSharpDriver
- *Outils ->Gérer les packages Nuget -> Gérer les packages Nuget pour la solution* 
  PM > Install-Package CassandraCSharpDriver
  
Go to your Cassandra software and :
Create your keyspace
Create your type
Create your table

Example :
```CQL
CREATE KEYSPACE IF NOT EXISTS reuters  WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor': 3 };
DROP TABLE IF EXISTS ARTICLE;
DROP TYPE IF EXISTS TEXTE;  
CREATE TYPE Texte(dateline VARCHAR, title VARCHAR, body VARCHAR);
CREATE TABLE Article (id INT PRIMARY KEY, date timestamp, places VARCHAR, companies VARCHAR, 
topics VARCHAR, exchanges VARCHAR,orgs VARCHAR, textes frozen<Texte>, people VARCHAR
);
SELECT * FROM article WHERE date <= '1987-03-05' allow filtering;
```
# CODE C#
#Increment k by 1, and begin by 5000
