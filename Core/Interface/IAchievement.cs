using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
