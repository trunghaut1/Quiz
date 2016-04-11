using System.Collections.Generic;
using System.Linq;
using Core.Interface;
using Core.Model;

namespace Core.Controller
{
    public class ReleaseHandle : IRelease
    {
        public List<Release> GetAllRelease()
        {
            return DataHelper<Entities, Release>.GetAll();
        }

        public Release GetReleaseById(int id)
        {
            return DataHelper<Entities, Release>.FindByPrimaryKey(id);
        }

        public bool Add(Release release)
        {
            DataHelper<Entities, Release>.Add(release);
            return true;
        }

        public bool Edit(Release release)
        {
            DataHelper<Entities, Release>.Edit(release);
            return true;
        }

        public bool Delete(int id)
        {
            Release release = DataHelper<Entities, Release>.FindByPrimaryKey(id);
            DataHelper<Entities, Release>.Remove(release);
            return true;
        }

        public int GetIdLastestRelease()
        {
            return DataHelper<Entities, Release>.GetAll().OrderByDescending(t => t.date).First().id;
        }

        public int GetIdLastestReleaseByType(int type)
        {
            return DataHelper<Entities, Release>.FindBy(t => t.ReleaseType.id.Equals(type)).OrderByDescending(t => t.date).First().id;
        }

        public List<Release> Get4LastedRelease()
        {
            return DataHelper<Entities, Release>.GetAll().OrderByDescending(t => t.date).Take(4).ToList();
        }

        public int GetSumReleases()
        {
            return DataHelper<Entities, Release>.GetAll().Count();
        }

        public List<Release> Get10ReleaseByIndex(int index)
        {
            return DataHelper<Entities, Release>.GetAll().OrderByDescending(t => t.date).Skip((index - 1) * 10).Take(10).ToList();
        }
    }
}
