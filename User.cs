using System;

namespace C868
{
    public class User
    {
        public int UserID;
        public string UserName;
        public string Password;
        public int Active;
        public DateTime CreateDate;
        public string CreatedBy;
        public DateTime LastUpdate;
        public string LastUpdateBy;

        public User(int userID, string userName, string password, int active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }
    }
}