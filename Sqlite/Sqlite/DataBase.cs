using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Sqlite
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
