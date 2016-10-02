using EmailEntities;
using EmailInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MailSelection.ViewModels
{
    public class MailSelectionViewModel : ViewModelBase
    {
        IEmailService emailService;
        //IEnumerable<EmailFolder> folders;

        public MailSelectionViewModel(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public IEnumerable<EmailFolder> Folders
        {
            get { return emailService.MailFolders; }
            //get { return folders; }
            //set
            //{
            //    if (folders != value)
            //    {
            //        folders = value;
            //        OnPropertyChanged("Folders");
            //    }
            //}
        }
    }
}
