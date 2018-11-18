using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EAD_Cwk2_EMoore_W1442006.Properties;

namespace EAD_Cwk2_EMoore_W1442006.Helpers
{
    public class ErrorHelper
    {
        public void SendError(Exception ex)
        {
            var innerException = string.IsNullOrEmpty(ex.InnerException?.Message) ? ex.InnerException?.Message : "None";

            var htmlBody = $"<p>Exception: {ex}</p>\r\n<hr />\r\n<p>Exception Message: {ex.Message}</p>\r\n<hr />\r\n<p>Inner Exceptions: {innerException}</p>";

            var mailMsg = new MailMessage
            {
                To = { "w1442006@my.westminster.ac.uk" },
                From = new MailAddress("EADCWK2@outlook.com"),
                Subject = "Error in EAD CWK2, ",
                Body = htmlBody,
                IsBodyHtml = true
            };

            var smtpConnection = new SmtpClient("smtp.live.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("EADCWK2@outlook.com", Settings.Default.Password),
                EnableSsl = true,
            };

            smtpConnection.Send(mailMsg);
        }
    }
}
