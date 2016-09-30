using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailEntities
{
    public class EmailFolderChangedEventArgs : EventArgs
    {
        public EmailFolderChangeType ChangeType { get; set; }
        public Email Email { get; set; }

        public EmailFolderChangedEventArgs() { }

        public EmailFolderChangedEventArgs(EmailFolderChangeType emailChangeType, Email email)
        {
            this.ChangeType = emailChangeType;
            this.Email = email;
        }
    }

    public enum EmailFolderChangeType
    {
        Add,
        Delete
    }
}
