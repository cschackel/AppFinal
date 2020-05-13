using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace FinalProject
{
    class Constants
    {
        public const string DatabaseFilename = "FinalSQLiteStar.db3";

        

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;


        public static NamedSize TextSize { get; set; } = NamedSize.Large;
        public static String TextSizeString { get; set; } = "Large";



        static Constants()
        {
            TextSize = NamedSize.Large;
            TextSizeString = "Large";
        }

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
