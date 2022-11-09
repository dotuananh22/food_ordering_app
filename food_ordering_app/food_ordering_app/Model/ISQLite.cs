using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace food_ordering_app.Model
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
