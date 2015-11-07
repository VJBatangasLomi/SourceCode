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
    public class DAUser
    {
        private DatabaseProviderFactory dbProviderFactory;

        public DAUser(DatabaseProviderFactory db)
        {
            FileConfigurationSource fileSource = new FileConfigurationSource(@"VJBatangas.LomiHouse.exe.config");
            this.dbProviderFactory = new DatabaseProviderFactory(fileSource);
        }

        public UserData ValidateLogin(string username, string password)
        {
            UserData data = new UserData();
            try
            {
                UserInfo info = new UserInfo();
                info = RetriveUserInformation(username, password);

                ResultData result = new ResultData();
                if (info != null)
                {
                   
                    result = UpdateLoginHistory("Login Successfully", info.EmployeeID);

                    if (result != null)
                    {
                        if (result.ResultCode == 0)
                        {
                            data.UserInformation = info;
                            data.ResultCode = ResultCodes.SUCCESSFUL_TRANSACTION;
                            data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.SUCCESSFUL_TRANSACTION);
                        }
                        else
                        {
                            data.ResultCode = ResultCodes.UNSUCCESSFUL_TRANSACTION;
                            data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.UNSUCCESSFUL_TRANSACTION);
                        }
                    } else
                    {
                        data.ResultCode = ResultCodes.UNSUCCESSFUL_TRANSACTION;
                        data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.UNSUCCESSFUL_TRANSACTION);
                    }
                } else
                {
                    data.ResultCode = ResultCodes.UNSUCCESSFUL_TRANSACTION;
                    data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.UNSUCCESSFUL_TRANSACTION);

                }
                
            }
            catch (Exception e)
            {
                data = new UserData();
                data.ResultCode = ResultCodes.UNSUCCESSFUL_TRANSACTION;
                data.ResultMessage = ResultCodes.toDesctiption(ResultCodes.UNSUCCESSFUL_TRANSACTION);
            }
            return data;
        }

        private UserInfo RetriveUserInformation(string username, string password)
        {
            List<UserInfo> userList = new List<UserInfo>();
            Database db = dbProviderFactory.Create(VJConstants.VJSQLConn);

            using (DbCommand cmd = db.GetSqlStringCommand("EXEC dbo.spSelLoginUser @username, @password"))
            {
                cmd.AddParameterName("@username");
                cmd.AddParameterName("@password");
                db.SetParameterValue(cmd, "@username", username);
                db.SetParameterValue(cmd, "@password", password);
                db.ExecuteSingleQuery<UserInfo>(cmd, this.Create, userList);
            }

            if (userList.Count > 0 )
            {
                return userList[0];
            }
            return null;
        }


        private ResultData UpdateLoginHistory(string eventName, int empid)
        {
            List<ResultData> result = new List<ResultData>();
            Database db = dbProviderFactory.Create(VJConstants.VJSQLConn);

            using (DbCommand cmd = db.GetSqlStringCommand("EXEC dbo.spUpdLoginHistory @empid, @eventname, @pc"))
            {
                cmd.AddParameterName("@empid");
                cmd.AddParameterName("@eventname");
                cmd.AddParameterName("@pc");
                db.SetParameterValue(cmd, "@empid", empid);
                db.SetParameterValue(cmd, "@eventname", eventName);
                db.SetParameterValue(cmd, "@pc", "PCName:" + System.Environment.MachineName + "|OS:" + System.Environment.OSVersion + "|Domain:" + System.Environment.UserDomainName + "|DomainUser:" + System.Environment.UserName);
                db.ExecuteSingleQuery<ResultData>(cmd, this.CreateUpdateLoginHistory, result);
            }

            if(result.Count > 0)
            {
                return result[0];
            }
            return null;
        }

        private UserInfo Create(IDataReader reader)
        {
            UserInfo u = new UserInfo()
            {
                FullName = DataAccessUtility.Retrieve<string>(reader, VJColumnName.CONST_FULL_NAME),
                UserName = DataAccessUtility.Retrieve<string>(reader, VJColumnName.CONST_USER_NAME),
                Password = DataAccessUtility.Retrieve<string>(reader, VJColumnName.CONST_PASSWORD),
                EmployeeID = DataAccessUtility.Retrieve<int>(reader, VJColumnName.CONST_EMP_ID),
                Status = DataAccessUtility.Retrieve<string>(reader, VJColumnName.CONST_STATUS),
                RoleId = DataAccessUtility.Retrieve<int>(reader, VJColumnName.CONST_ROLE_ID),
                LastLogin = DataAccessUtility.Retrieve<DateTime>(reader, VJColumnName.CONST_LAST_LOGIN)
            };

            return u;
        }

        private ResultData CreateUpdateLoginHistory(IDataReader reader)
        {
            ResultData r = new ResultData()
            {
                ResultCode = DataAccessUtility.Retrieve<int>(reader, VJColumnName.CONST_RESULT_CODE),
                ResultMessage = DataAccessUtility.Retrieve<string>(reader, VJColumnName.CONST_RESULT_MESSAGE)
            };

            return r;
        }

}
}
