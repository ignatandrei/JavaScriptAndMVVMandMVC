using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JqueryMVCRazor_DAL
{
    public class employee
    {
        public employee()
        {
            
        }
        public long IdEmployee { get; set; }
        public string NameEmployee { get; set; }
        public int iddepartament
        {
            get;
            set;
        }
        public bool Active { get; set; }
        public employee(long idEmployee, string nameEmployee, int depId)
        {
            this.IdEmployee = idEmployee;
            this.NameEmployee = nameEmployee;
            this.iddepartament = depId;
            this.Active = true;
        }

    }

    public class employeeList : List<employee>
    {
        public void Load()
        {
            //TODO: use a real database
            departmentList dl = new departmentList();
            dl.Load();
            this.Add(new employee(10, "Andrei Ignat", dl[0].IdDepartment));
            this.Add(new employee(15, "Andrei Rinea", dl[0].IdDepartment));
            this.Add(new employee(25, "Someone from HR", dl[1].IdDepartment));
            for (int i = 1; i < 100; i += 10)
            {
                Add(new employee(i, "Andrei Ignat "+i, dl[0].IdDepartment));
            }
        }

        public employee LoadId(int id)
        {
            //TODO : in real application must read database
            this.Load();
            return this[id];
        }
    }
}
