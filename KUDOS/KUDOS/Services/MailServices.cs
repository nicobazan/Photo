using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using KUDOS.Controllers.InsertRequest;
using System.Configuration;
using System.Configuration.Assemblies;

namespace KUDOS.Services
{
    public class MailServices : BaseService

    {

        public static dynamic send(EmailInsertRequest model)
        {

            Email from1 = new Email(model.from);

            string subject1 = model.subject;

            Content content1 = new Content("text/html", model.content);

            Execute(from1, subject1, content1).Wait();

            return model;
        }

        static async Task Execute(Email from2, string subject2, Content content2)
        {

            string apiKey = System.Configuration.ConfigurationManager.AppSettings["SendGrid"];

            dynamic sg = new SendGridAPIClient(apiKey);

            Email from = new Email();
            from = from2;

            string subject = subject2;

            Email to = new Email("nicobazan212@gmail.com");

            Content content = new Content();
            content = content2;

            Mail mail = new Mail(from, subject, to, content);

            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());

        }
    }
}
