using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group_Project.Pages.DatabaseConnection
{
    public class DatabaseConnect
    {
        public string DatabaseString() 
        {
            string DbString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusinessDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return DbString;    
        }
    }
}
