using System;
using System.Collections.Generic;
using Lesson4.Models;
using Lesson4.Test;
using Newtonsoft.Json;
using System.Data.SQLite;


namespace Lesson4.Classes
{
    public class Adapter : Target
    {
        private string DBName { get; }
        private string TableName { get; }
        private string ServiceName { get; }
        private string _Item { get; set; }
        private List<ProductNew> _Products { get; set; }

        public Adapter()
        {
            DBName = "usersdata.db";
            TableName = "ProductsNew";
            ServiceName = "ProductNew";
        }

        public override void GetFromService(string serviceName)
        {
            if (serviceName == "ProductNew")
            {
                var test = new TestData();
                _Item = test.ProductNew;
            }

        }
        public override void SaveToDB()
        {
            int count = 0;
            GetFromService(ServiceName);
           
            string sqlExpression = string.Concat("INSERT INTO ", TableName, "(ProductID, Article, Name, Cost, Count, DateExpired, IsMedical, TemperatureKeepFrom, TemperatureKeepTo) ",
                "VALUES (@ProductID, @Article, @Name, @Cost, @Count, @DateExpired, @IsMedical, @TemperatureKeepFrom, @TemperatureKeepTo)");
            try
            {
                using (var connection = new SQLiteConnection(string.Concat("Data Source=", DBName)))
                {
                    connection.Open();

                    var products = JsonConvert.DeserializeObject<List<ProductNew>>(_Item);

                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);

                    SQLiteParameter productIDParam;
                    SQLiteParameter articleParam;
                    SQLiteParameter nameParam;
                    SQLiteParameter costParam;
                    SQLiteParameter countParam;
                    SQLiteParameter dateExpiredParam;
                    SQLiteParameter ismedicalParam;
                    SQLiteParameter temperatureKeepFromParam;
                    SQLiteParameter temperatureKeepToParam;

                    foreach (var item in products)
                    {
                        productIDParam = new SQLiteParameter("@ProductID", item.ProductID);
                        command.Parameters.Add(productIDParam);

                        articleParam = new SQLiteParameter("@Article", item.Article);
                        command.Parameters.Add(articleParam);

                        nameParam = new SQLiteParameter("@Name", item.Name);
                        command.Parameters.Add(nameParam);

                        costParam = new SQLiteParameter("@Cost", item.Cost);
                        command.Parameters.Add(costParam);

                        countParam = new SQLiteParameter("@Count", item.Count);
                        command.Parameters.Add(countParam);

                        dateExpiredParam = new SQLiteParameter("@DateExpired", item.DateExpired);
                        command.Parameters.Add(dateExpiredParam);

                        ismedicalParam = new SQLiteParameter("@IsMedical", item.IsMedical);
                        command.Parameters.Add(ismedicalParam);

                        temperatureKeepFromParam = new SQLiteParameter("@TemperatureKeepFrom", item.TemperatureKeepFrom);
                        command.Parameters.Add(temperatureKeepFromParam);

                        temperatureKeepToParam = new SQLiteParameter("@TemperatureKeepTo", item.TemperatureKeepTo);
                        command.Parameters.Add(temperatureKeepToParam); 

                        count = count + command.ExecuteNonQuery();

                    }

                    Console.WriteLine($"Добавлено записей в таблицу {TableName}: {count}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public override void LoadFromDB()
        {
            try
            {
                var item = new ProductNew();
                using (var connection = new SQLiteConnection(string.Concat("Data Source=", DBName)))
                {
                    connection.Open();

                    var sqlExpression = string.Concat("SELECT * FROM ", TableName);

                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) // если есть данные
                        {
                            _Products = new List<ProductNew>();
                            while (reader.Read())   // построчно считываем данные
                            {

                                item.ProductID = reader.GetInt32(0);
                                item.Article = reader.GetString(1);
                                item.Name = reader.GetString(2);
                                item.Cost = reader.GetDecimal(3);
                                item.Count = reader.GetInt32(4);
                                item.DateExpired = reader.GetDateTime(5);
                                item.IsMedical = reader.GetInt32(6) != 0;
                                item.TemperatureKeepFrom = reader.GetInt32(7);
                                item.TemperatureKeepTo = reader.GetInt32(8);
    
                                _Products.Add(item);
                            }
                        }
                    }
                }

            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public override void CreateTable()
        {
            using (var connection = new SQLiteConnection(string.Concat("Data Source=", DBName)))
            {
                connection.Open();

                SQLiteCommand command;
                string sql;

                sql = string.Concat("drop table ", TableName);
                command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                sql = string.Concat("create table ", TableName, "(ProductID int NOT NULL PRIMARY KEY, Article int, Name text, Cost real, Count int, DateExpired text, IsMedical int, TemperatureKeepFrom int, TemperatureKeepTo int)");
                command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Таблица {0} создана", TableName);
            }
        }

        public override void Print()
        {

        Console.WriteLine("");
            Console.WriteLine($"Чтение данных из таблицы {TableName}...");
            foreach (var item in _Products)
            {
                Console.WriteLine("");
                Console.WriteLine($"ProductID : {item.ProductID}");
                Console.WriteLine($"Article : {item.Article}");
                Console.WriteLine($"Name : {item.Name}");
                Console.WriteLine($"Cost : {item.Cost}");
                Console.WriteLine($"Count : {item.Count}");
                Console.WriteLine($"DateExpired : {item.DateExpired}");
                Console.WriteLine($"IsMedical : {item.IsMedical}");
                Console.WriteLine($"TemperatureKeepFrom : {item.TemperatureKeepFrom}");
                Console.WriteLine($"TemperatureKeepTo : {item.TemperatureKeepTo}");

            }
        }
    }
}
