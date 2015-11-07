using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VJBatangas.LomiHouse.Common;
using VJBatangas.LomiHouse.Entity;
using System.Data.OleDb;
using System.Data;

namespace VJBatangas.LomiHouse.Data
{
    public class DAEmployeeMaster
    {
        VJConstants cons = new VJConstants();

        public List<EmployeeMaster> GetEmployeeList()
        {
            List<EmployeeMaster> emplist = new List<EmployeeMaster>();
            DataSet ds = new DataSet();

            string strconn = "";// cons.GetConnectionString;

            OleDbConnection conn = new OleDbConnection(strconn);
            
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM vw_GetEmployeeMaster", conn);
                
                da.Fill(ds, "EmployeeMaster");
            

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                EmployeeMaster emp = new EmployeeMaster()
                {
                    EmpId = Convert.ToInt32(dr["EmpId"].ToString()),
                    FirstName = dr["FirstName"].ToString(),
                    MiddleName = dr["MiddleName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    RoleId = Convert.ToInt32(dr["RoleId"].ToString()),
                    RoleName = dr["RoleName"].ToString(),
                    BranchId = Convert.ToInt32(dr["BranchId"].ToString()),
                    BranchName = dr["BranchName"].ToString()
                };
                emplist.Add(emp);
            }
            
            return emplist;
        }

        public List<EmployeeMaster> GetEmployeeNameList()
        {
            List<EmployeeMaster> emplist = new List<EmployeeMaster>();
            DataSet ds = new DataSet();

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\VJLomiDB.mdb;Jet OLEDB:Database Password=vj@dmin");

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT EmpId, FirstName, MiddleName, LastName FROM EmployeeMaster WHERE Status = 'A' AND RoleId <> 1 ORDER BY LastName", conn);

            da.Fill(ds, "EmployeeMaster");


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                EmployeeMaster emp = new EmployeeMaster()
                {
                    EmpId = Convert.ToInt32(dr["EmpId"].ToString()),
                    FirstName = dr["FirstName"].ToString(),
                    MiddleName = dr["MiddleName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                };
                emplist.Add(emp);
            }

            return emplist;
        }

        public EmployeeMaster GetEmployeeByEmpId(int EmpId)
        {
            EmployeeMaster emp = new EmployeeMaster();
            DataSet ds = new DataSet();

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\VJLomiDB.mdb;Jet OLEDB:Database Password=vj@dmin");

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM vw_GetEmployeeMaster WHERE EmpId=" + EmpId, conn);

            da.Fill(ds, "EmployeeMaster");

            EmployeeMaster objemp = new EmployeeMaster();
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                
                    emp.EmpId = Convert.ToInt32(dr["EmpId"].ToString());
                    emp.FirstName = dr["FirstName"].ToString();
                    emp.MiddleName = dr["MiddleName"].ToString();
                    emp.LastName = dr["LastName"].ToString();
                    emp.RoleId = Convert.ToInt32(dr["RoleId"].ToString());
                    emp.RoleName = dr["RoleName"].ToString();
                    emp.BranchId = Convert.ToInt32(dr["BranchId"].ToString());
                    emp.BranchName = dr["BranchName"].ToString();                                
            }

            return emp;
        }
    }
}
