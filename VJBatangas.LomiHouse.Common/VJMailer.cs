using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
namespace VJBatangas.LomiHouse.Common
{
    public class VJMailer
    {

        public Boolean SendEmailViaGmail(String htmlbody)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_SMTP_GOOGLE].ToString());
                var mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_MAIL_FROM.ToString()]);
                mail.To.Add(ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_MAIL_TO].ToString());
                mail.Subject = ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_MAIL_SUBJECT].ToString();
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = htmlbody;
                mail.Body = htmlBody;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_MAIL_GMAIL_USER].ToString(), ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_MAIL_GMAIL_PASSWORD].ToString());
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean SendEmailViaHotmail(String htmlbody)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_SMTP_HOTMAIL].ToString());
                var mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_MAIL_FROM.ToString()]);
                mail.To.Add(ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_MAIL_TO].ToString());
                mail.Subject = ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_MAIL_SUBJECT].ToString();
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = htmlbody;
                mail.Body = htmlBody;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_MAIL_OUTLOOK_USER].ToString(), ConfigurationManager.AppSettings[VJConstants.CONST_APPSETTINGS_MAIL_OUTLOOK_PASSWORD].ToString());
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        

        
    }
}
