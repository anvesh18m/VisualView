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
        public int UpdateUserDetails(UserDetails oUserDetails)
        {
            return dbConn.Execute($"Update UserDetails SET FirstName={oUserDetails.FirstName}, LastName={oUserDetails.LastName},Email ={oUserDetails.Email},CountryCode={oUserDetails.CountryCode},Phone={oUserDetails.Phone},Passport={oUserDetails.Passport} WHERE UserID={oUserDetails.UserID}");
        }
        #endregion
    }
}
