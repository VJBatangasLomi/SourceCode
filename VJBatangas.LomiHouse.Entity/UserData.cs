using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VJBatangas.LomiHouse.Entity
{
    public class UserData : BaseEntity
    {
        public UserInfo UserInformation = new UserInfo();

        public UserData()
        {
            this.UserInformation = new UserInfo();   
        }
    }

    public class UserInfo
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int EmployeeID { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int RoleId { get; set; }
        public DateTime LastLogin { get; set; }
        public UserInfo()
        {
        }
    }
}
