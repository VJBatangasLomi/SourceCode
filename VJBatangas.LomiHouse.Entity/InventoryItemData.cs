using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VJBatangas.LomiHouse.Entity
{
    public class InventoryItemData : BaseEntity
    {
        public List<InventoryItem> InventoryItemList { get; set; }

        public InventoryItemData()
        {
            this.InventoryItemList = new List<InventoryItem>();
        }
    }

    public class InventoryItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Available { get; set; }
        public string Remarks { get; set; }        
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public DateTime ModifiedDate { get; set; }

        public InventoryItem()
        {
        }
    }

}
