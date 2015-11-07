using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VJBatangas.LomiHouse.Common;
using VJBatangas.LomiHouse.Entity;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace VJBatangas.LomiHouse.Data
{
    public class DAInventorytem
    {

        #region "Declaration"
        private DatabaseProviderFactory dbProviderFactory;
        #endregion 
        
        #region "Methods"

        public DAInventorytem(DatabaseProviderFactory db)
        {
            FileConfigurationSource fileSource = new FileConfigurationSource(@"VJBatangas.LomiHouse.exe.config");
            this.dbProviderFactory = new DatabaseProviderFactory(fileSource);
        }

        public InventoryItemData InsertInventoryItem(string itemname,
                                                    int categoryid,
                                                    int quantity,
                                                    decimal price,
                                                    string isenable,
                                                    string remarks,
                                                    int by)
        {

            InventoryItemData data = new InventoryItemData();
            try
            {
                data.InventoryItemList = AddInventoryItems(itemname, categoryid, quantity, price, isenable, remarks, by);
                data.ResultCode = ResultCodes.SUCCESSFUL_TRANSACTION;
                data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.SUCCESSFUL_TRANSACTION);
            }
            catch
            {
                data = new InventoryItemData();
                data.ResultCode = ResultCodes.UNSUCCESSFUL_TRANSACTION;
                data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.UNSUCCESSFUL_TRANSACTION);
            }

            return data;

        }

        public InventoryItemData getInventoryItem(Int32 categoryid, Int32 itemid)
        {
            InventoryItemData data = new InventoryItemData();
            try
            {
                data.InventoryItemList = RetriveInventoryItems(categoryid, itemid);
                data.ResultCode = ResultCodes.SUCCESSFUL_TRANSACTION;
                data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.SUCCESSFUL_TRANSACTION);
            }
            catch
            {
                data = new InventoryItemData();
                data.ResultCode = ResultCodes.UNSUCCESSFUL_TRANSACTION;
                data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.UNSUCCESSFUL_TRANSACTION);
            }
            return data;
        }

        public InventoryItemData getInventoryItemByName(String itemname)
        {
            InventoryItemData data = new InventoryItemData();
            try
            {
                data.InventoryItemList = RetriveInventoryItemByName(itemname);
                data.ResultCode = ResultCodes.SUCCESSFUL_TRANSACTION;
                data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.SUCCESSFUL_TRANSACTION);
            }
            catch
            {
                data = new InventoryItemData();
                data.ResultCode = ResultCodes.UNSUCCESSFUL_TRANSACTION;
                data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.UNSUCCESSFUL_TRANSACTION);
            }
            return data;
        }

        private List<InventoryItem> AddInventoryItems(string itemname,
                                                    int categoryid,
                                                    int quantity,
                                                    decimal price,
                                                    string available,
                                                    string remarks,
                                                    int by)
        {
            List<InventoryItem> itemList = new List<InventoryItem>();
            Database db = dbProviderFactory.Create(VJConstants.VJSQLConn);

            using (DbCommand cmd = db.GetSqlStringCommand("EXEC dbo.InsertInventoryItem @itemname, @categoryid, @quantity, @price, @available, @remarks, @createdby"))
            {
                cmd.AddParameterName("@itemname");
                cmd.AddParameterName("@categoryid");
                cmd.AddParameterName("@quantity");
                cmd.AddParameterName("@price");
                cmd.AddParameterName("@available");
                cmd.AddParameterName("@remarks");
                cmd.AddParameterName("@createdby");

                db.SetParameterValue(cmd, "@itemname", itemname);
                db.SetParameterValue(cmd, "@categoryid", categoryid);
                db.SetParameterValue(cmd, "@quantity", quantity);
                db.SetParameterValue(cmd, "@price", price);
                db.SetParameterValue(cmd, "@available", available);
                db.SetParameterValue(cmd, "@remarks", remarks);
                db.SetParameterValue(cmd, "@createdby", by);

                db.ExecuteSingleQuery<InventoryItem>(cmd, this.Create, itemList);
            }

            return itemList;
        }

        public InventoryItemData DeleteInventoryItem(int itemid)
        {
            InventoryItemData data = new InventoryItemData();
            try
            {
                data.InventoryItemList = RemoveInventoryItemByName(itemid);
                data.ResultCode = ResultCodes.SUCCESSFUL_TRANSACTION;
                data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.SUCCESSFUL_TRANSACTION);
            }
            catch
            {
                data = new InventoryItemData();
                data.ResultCode = ResultCodes.UNSUCCESSFUL_TRANSACTION;
                data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.UNSUCCESSFUL_TRANSACTION);
            }
            return data;
        }

        private List<InventoryItem> RetriveInventoryItemByName(String itemname)
        {
            List<InventoryItem> itemList = new List<InventoryItem>();
            Database db = dbProviderFactory.Create(VJConstants.VJSQLConn);

            using (DbCommand cmd = db.GetSqlStringCommand("EXEC dbo.GetInventoryItemByName @itemname"))
            {
                cmd.AddParameterName("@itemname");
                db.SetParameterValue(cmd, "@itemname", itemname);
                db.ExecuteSingleQuery<InventoryItem>(cmd, this.Create, itemList);
            }

            return itemList;
        }

        private List<InventoryItem> RetriveInventoryItems(Int32 categoryid, Int32 itemid)
        {
            List<InventoryItem> itemList = new List<InventoryItem>();
            Database db = dbProviderFactory.Create(VJConstants.VJSQLConn);

            using (DbCommand cmd = db.GetSqlStringCommand("EXEC dbo.GetInventoryItem @categoryid, @itemid"))
            {
                cmd.AddParameterName("@categoryid");
                cmd.AddParameterName("@itemid");
                db.SetParameterValue(cmd, "@categoryid", categoryid);
                db.SetParameterValue(cmd, "@itemid", itemid);
                db.ExecuteSingleQuery<InventoryItem>(cmd, this.Create, itemList);
            }

            return itemList;
        }

        private List<InventoryItem> RemoveInventoryItemByName(int itemid)
        {
            List<InventoryItem> itemList = new List<InventoryItem>();
            Database db = dbProviderFactory.Create(VJConstants.VJSQLConn);

            using (DbCommand cmd = db.GetSqlStringCommand("EXEC dbo.DeleteInventoryItem @itemid"))
            {
                cmd.AddParameterName("@itemid");
                db.SetParameterValue(cmd, "@itemid", itemid);
                db.ExecuteSingleQuery<InventoryItem>(cmd, this.Create, itemList);
            }

            return itemList;
        }

        private InventoryItem Create(IDataReader reader)
        {
            InventoryItem i = new InventoryItem()
            {
                ItemId = DataAccessUtility.Retrieve<int>(reader, VJColumnName.CONST_ITEM_ID),
                ItemName = DataAccessUtility.Retrieve<string>(reader, VJColumnName.CONST_ITEM_NAME),
                CategoryId = DataAccessUtility.Retrieve<int>(reader, VJColumnName.CONST_CATEGORY_ID),
                CategoryName = DataAccessUtility.Retrieve<string>(reader, VJColumnName.CONST_CATEGORY_NAME),
                Quantity = DataAccessUtility.Retrieve<int>(reader, VJColumnName.CONST_QUANTITY),
                Price = DataAccessUtility.Retrieve<decimal>(reader, VJColumnName.CONST_PRICE),
                Available = DataAccessUtility.Retrieve<string>(reader, VJColumnName.CONST_AVAILABLE),
                Remarks = DataAccessUtility.Retrieve<string>(reader, VJColumnName.CONST_REMARKS),
                CreatedBy = DataAccessUtility.Retrieve<int>(reader, VJColumnName.CONST_CREATED_BY),
                CreatedByName = DataAccessUtility.Retrieve<string>(reader, VJColumnName.CONST_CREATED_BY_NAME),
                CreatedDate = DataAccessUtility.Retrieve<DateTime>(reader, VJColumnName.CONST_CREATED_DATE),
                ModifiedBy = DataAccessUtility.Retrieve<int>(reader, VJColumnName.CONST_MODIFIED_BY),
                ModifiedByName = DataAccessUtility.Retrieve<string>(reader, VJColumnName.CONST_MODIFIED_BY_NAME),
                ModifiedDate = DataAccessUtility.Retrieve<DateTime>(reader, VJColumnName.CONST_MODIFIED_DATE)
            };

            return i;
        }

        #endregion
      
    }
}
