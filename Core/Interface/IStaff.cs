using Core.Model;
using System.Collections.Generic;

namespace Core.Interface
{
    interface IStaff
    {
        bool Add(Staff staff);
        bool Edit(Staff staff);
        bool Delete(int id);
        List<Staff> getAllStaff();
        Staff GetStaffById(int id);
    }
}
