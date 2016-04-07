using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
