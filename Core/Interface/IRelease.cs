using Core.Model;
using System.Collections.Generic;

namespace Core.Interface
{
    interface IRelease
    {
        List<Release> GetAllRelease();
        Release GetReleaseById(int id);
        bool Add(Release release);
        bool Edit(Release release);
        bool Delete(int id);
        int GetIdLastestRelease();
        int GetIdLastestReleaseByType(int type);
        List<Release> Get4LastedRelease();
        int GetSumReleases();
        List<Release> Get10ReleaseByIndex(int index);
    }
}
