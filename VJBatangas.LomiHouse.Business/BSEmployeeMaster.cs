using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VJBatangas.LomiHouse.Data;
using VJBatangas.LomiHouse.Entity;
using VJBatangas.LomiHouse.Common;

namespace VJBatangas.LomiHouse.Business
{
    public class BSEmployeeMaster
    {
        public EmployeeMaster GetEmployeeByEmpId(int empid)
        {
            EmployeeMaster emp = new EmployeeMaster();
            DAEmployeeMaster daemp = new DAEmployeeMaster();

            emp = daemp.GetEmployeeByEmpId(empid);

            return emp;
        }

        public List<EmployeeMaster> GetEmployeeList()
        {
            List<EmployeeMaster> emplist = new List<EmployeeMaster>();
            DAEmployeeMaster daemp = new DAEmployeeMaster();

            emplist = daemp.GetEmployeeList();

            return emplist;
        }

        public List<EmployeeMaster> GetEmployeeNameList()
        {
            List<EmployeeMaster> emplist = new List<EmployeeMaster>();
            DAEmployeeMaster daemp = new DAEmployeeMaster();

            emplist = daemp.GetEmployeeNameList();

            return emplist;
        }
    }
}
