using Mono.TextTemplating;
using Doctor.Model.App;
using System.Net.Mail;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Net;
namespace Doctor.presentation.WebAPP.Helper
{
    public   static class EmaillSetting
    {
        public static void SendEmail(Email email)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;  
            smtpClient.Credentials = new NetworkCredential("hagersayed573@gmail.com", "ygmq cajy vypk bhhi");
            smtpClient.Send(email.From,email.To,email.Title,email.Body);
        }
    }
}
  