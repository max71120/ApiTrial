﻿using System.Data.Common;
using System.Globalization;

namespace Tienda.Conexion
{
    public class Conexionbd
    {
        private string connectionString = String.Empty;
        public Conexionbd()
        {
            var builder = new ConfigurationBuilder().
            SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = builder.GetSection("ConnectionStrings:conexionmaestra").Value;
        }
        public string cadenaSQL()
        { return connectionString; }
            
            
    }
}
