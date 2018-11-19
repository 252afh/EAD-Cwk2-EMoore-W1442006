namespace EAD_Cwk2_EMoore_W1442006.Helpers
{
    using Properties;
    using System;
    using System.Net;
    using System.Net.Mail;

    /// <summary>
    /// An instance of <see cref="ErrorHelper"/> used to send exception details to my university email
    /// </summary>
    public static class ErrorHelper
    {
        /// <summary>
        /// Handles formatting and sending the exception information
        /// </summary>
        /// <param name="ex">The exception to be included in the email</param>
        public static void SendError(Exception ex)
        {
            try
            {
                var innerException = string.IsNullOrEmpty(ex.InnerException?.Message)
                    ? ex.InnerException?.Message
                    : "None";

                var htmlBody =
                    $"<p>Exception: {ex}</p>\r\n<hr />\r\n<p>Exception Message: {ex.Message}</p>\r\n<hr />\r\n<p>Inner Exceptions: {innerException}</p>";

                var mailMsg = new MailMessage
                {
                    To = {"w1442006@my.westminster.ac.uk"},
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
            catch (Exception)
            {
                // Ignored because error cannot be logged if this method errors
            }
        }
    }
}
