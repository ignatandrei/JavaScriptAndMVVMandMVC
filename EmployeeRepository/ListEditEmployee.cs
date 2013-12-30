using System.Collections.Generic;
using JqueryMVCRazor_DAL;
using System.Linq;

namespace JqueryMVCRazor_Repository
{
    public class ListEmployeesViewModel
    {
       
        public employeeList AllEmployees { get; set; }
        public departmentList DepartmentList{ get; private set; }
        public void Load()
        {
            DepartmentList = new departmentList();
            DepartmentList.Load();
            AllEmployees = new employeeList ();
            AllEmployees.Load();//TODO: in real application make paging/sorting
        }
        public bool Save(long[] deletedIds)
        {
            if (deletedIds != null && deletedIds.Length > 0)
            {
                //TODO: delete from database
                AllEmployees.RemoveAll(item => deletedIds.Contains(item.IdEmployee));
            }
            //TODO: save data
            //after saving, the id of the new employees are changing in database from 0  to values
            //I simulate here this behaviour
            long max = 0;
            foreach (var item in AllEmployees)
            {
                if (max < item.IdEmployee)
                    max = item.IdEmployee;
            }
            max++;
            var newEmps = AllEmployees.FindAll(item => item.IdEmployee == 0);
            foreach (var item in newEmps)
            {
                item.IdEmployee = max++;
            }
            return true;
        }


    }
}
