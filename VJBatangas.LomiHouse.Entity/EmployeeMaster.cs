using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VJBatangas.LomiHouse.Entity
{
    public class EmployeeMaster
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { 
            get { return LastName + ", " + FirstName + " " + MiddleName; }
            set { }
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public DateTime ModifiedDate { get; set; }

        
    }
}
