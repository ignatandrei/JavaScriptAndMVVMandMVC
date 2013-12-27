using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JqueryMVCRazor_DAL
{
   
    public class department
    {
        public int IdDepartment { get; set; }
        public string NameDepartment { get; set; }
        public department(){}
        public department(int idDepartment, string nameDepartment)
        {
            this.IdDepartment = idDepartment;
            this.NameDepartment = nameDepartment;
        }

    }

    public class departmentList : List<department>
    {
        public void Load()
        {
            this.Add(new department(12, "IT"));
            this.Add(new department(23, "HR"));
        }
    }
}
