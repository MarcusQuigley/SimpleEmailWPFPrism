using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailEntities
{
    public class EmailFolder
    {
        List<Email> emails;

        public event EventHandler<EmailFolderChangedEventArgs> EmailChanged;

        public EmailFolder()
            : this(new List<Email>())
        { }

        public EmailFolder(Email[] emails)
            // : this((IEnumerable < Email >) emails)
            : this(emails.ToList<Email>())
        { }

        public EmailFolder(IEnumerable<Email> emails)
        {
            this.emails = new List<Email>();
            foreach (Email email in emails)
            {
                email.EnFolder(this);
            }
        }

        public void DeleteMail(Email email)
        {
            lock (this.emails)
            {
                this.emails.Remove(email);
            }
            OnEmailChanged(EmailFolderChangeType.Delete, email);

         }

        public void AddMail(Email email)
        {
            lock (this.emails)
            {
                this.emails.Add(email);
            }
            OnEmailChanged(EmailFolderChangeType.Add, email);
        }

        protected void OnEmailChanged(EmailFolderChangeType changeType, Email email)
        {
            if (EmailChanged != null)
            {
                EmailChanged(this,
                    new EmailFolderChangedEventArgs(changeType, email));
            }
        }
    }
}
