using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
namespace VJBatangas.LomiHouse.Data
{
    public class DataAccessHelper
    {
        DatabaseProviderFactory dbProviderFactory;

        public DataAccessHelper()
        {
            FileConfigurationSource fileSource = new FileConfigurationSource(@"app.config");

            this.dbProviderFactory = new DatabaseProviderFactory(fileSource);
        }
    }
}
