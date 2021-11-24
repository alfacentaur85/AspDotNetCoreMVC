using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lesson4.Interfaces;

namespace Lesson4.Interfaces
{
    public interface IReposytory
    {
        public string connectionString { 
            get
            {
                return connectionString;
            }
            private set 
            {
                connectionString = "Data Source=usersdata.db";
            }
        } 
        public void LoadFromDB();
        public void SaveToDB();
        public void CreateDB();
        public void CreateTable();

    }
}
