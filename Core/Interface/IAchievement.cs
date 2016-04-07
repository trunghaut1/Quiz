using Core.Model;
using System.Collections.Generic;

namespace Core.Interface
{
    interface IAchievement
    {
        bool AddInfo(Info info);
        bool AddHistory(History history);
        List<Info> GetInfoOfUser(string userid);
        List<History> GetHistoryOfUser(string userid);
    }
}
