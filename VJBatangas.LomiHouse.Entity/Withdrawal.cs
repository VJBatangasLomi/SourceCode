using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VJBatangas.LomiHouse.Entity
{
    public class Withdrawal
    {
        public int TransactionId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int AvailableStock { get; set; }
        public int Quatity { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Remarks { get; set; }
        public string PaymentStatus { get; set; }
        public decimal SubTotal { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime  CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public DateTime  ModifiedDate { get; set; }
    }
}
