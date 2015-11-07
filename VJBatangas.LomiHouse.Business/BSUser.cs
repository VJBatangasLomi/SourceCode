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
    public class BSUser
    {
        protected DatabaseProviderFactory dbProviderFactory;
        protected DAUser da;
        protected UserData data;

        public UserInfo ValidateLogin(string username, string password)
        {

            if (String.IsNullOrEmpty(username.Trim()) || String.IsNullOrEmpty(password.Trim()))
            {
                return null;
            }
            else
            {
                da = new DAUser(dbProviderFactory);
                data = new UserData();

                data = da.ValidateLogin(username, password);

                if (data.ResultCode == ResultCodes.SUCCESSFUL_TRANSACTION)
                {
                    if (data.UserInformation != null)
                    {
                        return data.UserInformation;
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
}
