using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VJBatangas.LomiHouse.Data;
using VJBatangas.LomiHouse.Entity;
using VJBatangas.LomiHouse.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace VJBatangas.LomiHouse.Business
{
    public class BSCategory
    {

        private DatabaseProviderFactory dbProviderFactory;
        private DACategory da;
        private CategoryData data;

        public List<Category> GetCategoryList(int categoryid)
        {
            da = new DACategory(dbProviderFactory);
            data = new CategoryData();

            data = da.GetCategory(categoryid);

            if (data.ResultCode == ResultCodes.SUCCESSFUL_TRANSACTION)
            {
                if (data.CategoryList.Count > 0)
                {
                    return data.CategoryList;
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

    }
}
