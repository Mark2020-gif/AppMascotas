using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppMascotas
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
