using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace SimpleEmail
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Startup += ((o,r) => {
                Bootstrapper bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            });

            this.LoadCompleted +=((o,r) => {
                Console.Beep();
            });
        }
    }
}
