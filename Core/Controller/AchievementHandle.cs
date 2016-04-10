using Core.Interface;
using Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Core.Controller
{
    public class AchievementHandle : IAchievement
    {
        public bool AddInfo(Model.Info info)
        {
            Info origen = DataHelper<Entities, Info>.FindBy(t => t.UserId.Equals(info.UserId) && t.SubId.Equals(info.SubId)).FirstOrDefault();
            if (origen != null)
            {
                origen.NumAnswer += info.NumAnswer;
                origen.NumAnswerTrue += info.NumAnswerTrue;
                origen.TimeUse += info.TimeUse;
                DataHelper<Entities, Info>.Add(info);
                return true;
            }

            return false;
        }

        public bool AddHistory(Model.History history)
        {
            DataHelper<Entities, History>.Add(history);
            return true;
        }

        public List<Model.Info> GetInfoOfUser(string userid)
        {
            return DataHelper<Entities, Info>.FindBy(t => t.UserId.Equals(userid)).ToList();
        }

        public List<Model.History> GetHistoryOfUser(string userid)
        {
            return DataHelper<Entities, History>.FindBy(t => t.UserId.Equals(userid)).ToList();
        }
    }
}
