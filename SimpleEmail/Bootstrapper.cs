using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SimpleEmail
{
    public class Bootstrapper : UnityBootstrapper
    {
        Shell shell;
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml
                   (System.IO.File.OpenRead("catalog.xaml"));
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = shell;
            Application.Current.MainWindow.Show();
        }

        protected override System.Windows.DependencyObject CreateShell()
        {
            shell = new Shell();
            return shell;
        }
    }
}
