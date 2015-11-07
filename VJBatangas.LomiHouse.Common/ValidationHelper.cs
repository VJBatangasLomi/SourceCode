using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VJBatangas.LomiHouse.Common
{
    public class ValidationHelper
    {
        public static void ValidateNonNullArgument(object value, String field)
        {
            if (value == null)
            {
                throw new ArgumentNullException(field);
            }
        }
    }
}
