using System;
using System.Collections.Generic;
using Lesson4.Interfaces;
using Newtonsoft.Json;
using Lesson4.Models;
using Lesson4.Test;
using System.Data.SQLite;

namespace Lesson4.Classes
{
    public class Target : ICommon
    {
        private string DBName { get; }
        private string TableName { get; }
        private string ServiceName { get; }
        private string _Item { get; set; }
        private List<Product> _Products { get; set; }

        public Target()
        {
            DBName = "usersdata.db";
            TableName = "Products";
            ServiceName = "Product";
        }
        public virtual void GetFromService(string serviceName)
        {
            if (serviceName == "Product")
            {
                var test = new TestData();
                _Item = test.Product;
            }

        }

        public virtual void LoadFromDB()
        {
            try
            {
                var item = new Product();
                using (var connection = new SQLiteConnection(string.Concat("Data Source=", DBName)))
                {
                    connection.Open();

                    var sqlExpression = string.Concat("SELECT * FROM ", TableName);

                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) // если есть данные
                        {
                            _Products = new List<Product>();
                            while (reader.Read())   // построчно считываем данные
                            {

                                item.ProductID = reader.GetInt32(0);
                                item.Article = reader.GetInt32(1);
                                item.Name = reader.GetString(2);
                                item.Notification = reader.GetString(3);
                                item.Weight = reader.GetFloat(4);
                                item.Long = reader.GetFloat(5);
                                item.Height = reader.GetFloat(6);
                                item.Width = reader.GetFloat(7);
                                item.Price = reader.GetDecimal(8);
                                item.DateMade = reader.GetDateTime(9);
                                item.Count = reader.GetInt32(10);

                                _Products.Add(item);
                            }
                        }
                    }
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public virtual void SaveToDB()
        {
            int count = 0;
            GetFromService(ServiceName);

            string sqlExpression = string.Concat("INSERT INTO ", TableName, "(ProductID, Article, Name, Notification, Weight, Long, Height, Width, Price, DateMade, Count) ",
                "VALUES (@ProductID, @Article, @Name, @Notification, @Weight, @Long, @Height, @Width, @Price, @DateMade, @Count)");
            try
            {
                using (var connection = new SQLiteConnection(string.Concat("Data Source=", DBName)))
                {
                    connection.Open();

                    var products = JsonConvert.DeserializeObject<List<Product>>(_Item);

                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);

                    SQLiteParameter productIDParam;
                    SQLiteParameter articleParam;
                    SQLiteParameter nameParam;
                    SQLiteParameter notificationParam;
                    SQLiteParameter weightParam;
                    SQLiteParameter longParam;
                    SQLiteParameter heightParam;
                    SQLiteParameter widthParam;
                    SQLiteParameter priceParam;
                    SQLiteParameter dateMadeParam;
                    SQLiteParameter countParam;


                    foreach (var item in products)
                    {
                        productIDParam = new SQLiteParameter("@ProductID", item.ProductID);
                        command.Parameters.Add(productIDParam);

                        articleParam = new SQLiteParameter("@Article", item.Article);
                        command.Parameters.Add(articleParam);

                        nameParam = new SQLiteParameter("@Name", item.Name);
                        command.Parameters.Add(nameParam);

                        notificationParam = new SQLiteParameter("@Notification", item.Notification);
                        command.Parameters.Add(notificationParam);

                        weightParam = new SQLiteParameter("@Weight", item.Weight);
                        command.Parameters.Add(weightParam);

                        longParam = new SQLiteParameter("@Long", item.Long);
                        command.Parameters.Add(longParam);

                        heightParam = new SQLiteParameter("@Height", item.Height);
                        command.Parameters.Add(heightParam);

                        widthParam = new SQLiteParameter("@Width", item.Width);
                        command.Parameters.Add(widthParam);

                        priceParam = new SQLiteParameter("@Price", item.Price);
                        command.Parameters.Add(priceParam);

                        dateMadeParam = new SQLiteParameter("@DateMade", item.DateMade);
                        command.Parameters.Add(dateMadeParam);

                        countParam = new SQLiteParameter("@Count", item.Count);
                        command.Parameters.Add(countParam);


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

        public virtual void Print()
        {
            Console.WriteLine("");
            Console.WriteLine($"Чтение данных из таблицы {TableName}...");
            foreach (var item in _Products)
            {
                Console.WriteLine("");
                Console.WriteLine($"ProductID : {item.ProductID}");
                Console.WriteLine($"Article : {item.Article}");
                Console.WriteLine($"Name : {item.Name}");
                Console.WriteLine($"Notification : {item.Notification}");
                Console.WriteLine($"Weight : {item.Weight}");
                Console.WriteLine($"Long : {item.Long}");
                Console.WriteLine($"Height : {item.Height}");
                Console.WriteLine($"Width : {item.Width}");
                Console.WriteLine($"Price : {item.Price}");
                Console.WriteLine($"DateMade : {item.DateMade}");
                Console.WriteLine($"Count : {item.Count}");
            }
        }

        public void CreateDB()
        {
            if (!System.IO.File.Exists(DBName))
            {
                SQLiteConnection.CreateFile(DBName);
                using (var connection = new SQLiteConnection(string.Concat("Data Source=", DBName)))
                {
                    connection.Open();

                    Console.WriteLine("БД {0} создана", DBName);
                }
            }
        }

        public virtual void CreateTable()
        {
            using (var connection = new SQLiteConnection(string.Concat("Data Source=", DBName)))
            {
                connection.Open();
                
                SQLiteCommand command;
                string sql;

                sql = string.Concat("drop table ", TableName);
                command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                sql = string.Concat("create table ", TableName, "(ProductID int NOT NULL PRIMARY KEY, Article int, Name text, Notification text, Weight real, Long real, Height real, Width real, Price real, DateMade text, Count int)");
                command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Таблица {0} создана", TableName);
            }
        }
    }
}
