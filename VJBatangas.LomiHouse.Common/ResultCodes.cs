using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VJBatangas.LomiHouse.Common
{
    public class ResultCodes
    {
        public const Int32 SUCCESSFUL_TRANSACTION = 0;

        public const Int32 UNSUCCESSFUL_TRANSACTION = -100;

        public static String toDesctiption(Int32 code)
        {
            switch (code)
            {
                case SUCCESSFUL_TRANSACTION: return "Successful Transaction";
                case UNSUCCESSFUL_TRANSACTION: return "Unsuccessful Transaction";
                default: return "Unknow error. Code is not registered or recognized.";
            }
        }
    }
}
