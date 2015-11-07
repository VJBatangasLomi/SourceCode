using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VJBatangas.LomiHouse.Data;
using VJBatangas.LomiHouse.Entity;
using VJBatangas.LomiHouse.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace VJBatangas.LomiHouse.Business
{
    public class BSInventoryItem
    {
        #region "Declaration"
        protected DatabaseProviderFactory dbProviderFactory;
        protected DAInventorytem da;
        protected InventoryItemData data;
        #endregion

        #region "Method"
        public InventoryItem getInventoryItem(Int32 itemid)
        {

            da = new DAInventorytem(dbProviderFactory);
            data = new InventoryItemData();

            data = da.getInventoryItem(0, itemid);

            if (data.ResultCode == ResultCodes.SUCCESSFUL_TRANSACTION)
            {
                if (data.InventoryItemList.Count > 0)
                {
                    return data.InventoryItemList[0];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public List<InventoryItem> getInventoryItem(Int32 categoryid, Int32 itemid)
        {

            da = new DAInventorytem(dbProviderFactory);
            data = new InventoryItemData();

            data = da.getInventoryItem(categoryid, itemid);

            if (data.ResultCode == ResultCodes.SUCCESSFUL_TRANSACTION)
            {
                if (data.InventoryItemList.Count > 0)
                {
                    return data.InventoryItemList;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public Boolean checkInventoryItemByName(String itemname)
        {

            da = new DAInventorytem(dbProviderFactory);
            data = new InventoryItemData();

            data = da.getInventoryItemByName(itemname);

            if (data.ResultCode == ResultCodes.SUCCESSFUL_TRANSACTION)
            {
                if (data.InventoryItemList.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public Boolean InsertInventoryItem(string itemname,
                                        int categoryid,
                                        int quantity,
                                        decimal price,
                                        string available,
                                        string remarks,
                                        int by)
        {
            Boolean result = false;
            da = new DAInventorytem(dbProviderFactory);
            data = new InventoryItemData();

            data = da.InsertInventoryItem(itemname, categoryid, quantity, price, available, remarks, by);

            if (data.ResultCode == ResultCodes.SUCCESSFUL_TRANSACTION)
            {
                result = true;
            }

            return result;

        }

        public Boolean DeleteInventoryItem(int itemid)
        {

            da = new DAInventorytem(dbProviderFactory);
            data = new InventoryItemData();

            data = da.DeleteInventoryItem(itemid);

            if (data.ResultCode == ResultCodes.SUCCESSFUL_TRANSACTION)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion
                
    }
}
