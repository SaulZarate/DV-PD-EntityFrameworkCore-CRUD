using System;
using System.Collections.Generic;
using System.Text;

namespace pruebasEntityFramework.Helpers
{
    class Config
    {
        private const String SERVER = "localhost";
        private const String DATABASE = "pruebasefcore";
        private const String PORT = "3306";
        private const String USER = "root";
        private const String PASSWORD = "";

        public static String GetConnectionString()
        {
            return $"server={Config.SERVER};user={Config.USER};database={Config.DATABASE};port={Config.PORT};password={Config.PASSWORD}";
        }

    }
}
