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
    public class DACategory
    {

        private DatabaseProviderFactory dbProviderFactory;
		private const String CONST_CATEGORY_ID = "categoryid";
        private const String CONST_CATEGORY_NAME = "categoryname";
        private const String CONST_DESCRIPTION = "description";
        private const String CONST_IS_ENABLE = "isenable";
        private const String CONST_CREATED_BY = "createdby";
        private const String CONST_CREATED_DATE = "createddate";
        private const String CONST_MODIFIED_BY = "modifiedby";
        private const String CONST_MODIFIED_DATE = "modifieddate";

        public DACategory(DatabaseProviderFactory dbProviderFactory)
        {
            FileConfigurationSource fileSource = new FileConfigurationSource(@"VJBatangas.LomiHouse.exe.config");
            this.dbProviderFactory = new DatabaseProviderFactory(fileSource);
        }

        public CategoryData GetCategory(int categoryid)
        {
            CategoryData data = new CategoryData();

            try
            {
                data.CategoryList = RetriveDataList(categoryid);
            }
            catch{
            }

            return data;
        }

        private List<Category> RetriveDataList(int categoryid)
        {
            List<Category> datalist = new List<Category>();
            Database db = dbProviderFactory.Create(VJConstants.VJSQLConn);

            using (DbCommand cmd = db.GetSqlStringCommand("EXEC dbo.GetCategory @catid"))
            {
                cmd.AddParameterName("@catid");
                db.SetParameterValue(cmd, "@catid", categoryid != 0 ? categoryid : 0);
                db.ExecuteSingleQuery<Category>(cmd, this.Create, datalist);

            }

            return datalist;
        }

        private Category Create(IDataReader reader)
        {
            Category c = new Category()
            {
                CategoryId = DataAccessUtility.Retrieve<int>(reader, CONST_CATEGORY_ID),
                CategoryName = DataAccessUtility.Retrieve<string>(reader, CONST_CATEGORY_NAME),
                Description = DataAccessUtility.Retrieve<string>(reader, CONST_DESCRIPTION),
                IsEnable = DataAccessUtility.Retrieve<string>(reader, CONST_IS_ENABLE),
                CreatedBy = DataAccessUtility.Retrieve<int>(reader, CONST_CREATED_BY),
                CreatedDate = DataAccessUtility.Retrieve<DateTime>(reader, CONST_CREATED_DATE),
                ModifiedBy = DataAccessUtility.Retrieve<int>(reader, CONST_MODIFIED_BY),
                ModifiedDate = DataAccessUtility.Retrieve<DateTime>(reader, CONST_MODIFIED_DATE)
            };

            return c;
        }
        
    }
}
