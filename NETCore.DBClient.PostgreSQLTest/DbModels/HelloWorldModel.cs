using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETCore.DBClient.PostgreSQLTest.DbModels
{
    internal class HelloWorldModel
    {
        public int Id { get; init; }
        public string Quote { get; init; }
    }
}
