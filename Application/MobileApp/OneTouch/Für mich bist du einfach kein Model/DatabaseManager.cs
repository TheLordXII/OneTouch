using System;

namespace OneTouch.FürmichbistdueinfachkeinModel
{
    public static class DatabaseManager
    {
        public static ReturnCode Connect()
        {
            return ReturnCode.success;
        }

        public static ReturnCode CheckCredentials(string Username, string Password)
        {
            
            return ReturnCode.wrongPassword;
        }
    }
}
