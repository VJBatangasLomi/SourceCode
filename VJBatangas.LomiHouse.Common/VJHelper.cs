using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace VJBatangas.LomiHouse.Common
{
    public class VJHelper
    {
        
        public string GetConnectionString (String key)
        {
            return ConfigurationManager.ConnectionStrings[key].ToString();     
        }
    }
}
