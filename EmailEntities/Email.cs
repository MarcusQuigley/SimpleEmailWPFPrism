using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailEntities
{
    public class Email
    {
        EmailFolder folder;

        public Email()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Sent { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public void Delete()
        {
            if (this.folder != null)
                this.folder.DeleteMail(this);
        }

        public void EnFolder(EmailFolder folder)
        {
            this.Delete();
            this.folder = folder;
            this.folder.AddMail(this);
        }

        public static Email Create()
        {
        Email email = new Email()
        {
            To = "to@mailserver.com",
            From = "from@mailserver.com",
            Sent = DateTime.Now
        };
            email.Subject = string.Format("Email {0} Subject Line ", email.Id);
            email.Body = string.Format("Email {0} Body Text", email.Id);
            return email;
        }
    }
}
