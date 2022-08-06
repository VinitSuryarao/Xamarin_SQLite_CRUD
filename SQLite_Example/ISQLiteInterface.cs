using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLite_Example
{
    public interface ISQLiteInterface
    {
        SQLiteConnection GetConnectionWithDB();
    }
}
