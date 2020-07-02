using innomick.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace innomick.DataBase
{
    public class DataAccess
    {
        SQLiteConnection dbConn;
        public DataAccess(string dbstring)
        {
            //dbConn = DependencyService.Get<ISQLite>().GetConnection();
            dbConn = new SQLiteConnection(dbstring);
            dbConn.CreateTable<UserDetails>();
        }
        #region Users
        public UserDetails GetUserDetails(int Id)
        {
            return dbConn.Query<UserDetails>("Select * From UserDetails where UserID = ?", Id).FirstOrDefault();
        }
        public int SaveUserDetails(UserDetails oUserDetails)
        {
            return dbConn.Insert(oUserDetails);
        }
        #endregion
    }
}
