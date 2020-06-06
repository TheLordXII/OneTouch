using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApp.FürmichbistdueinfachkeinModel;


    public interface IFriendService
    {
        Task<IEnumerable<User>> Refresh();
    }
