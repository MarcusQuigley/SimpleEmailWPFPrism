using EmailInterfaces;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailService.ModuleDefinitions
{
    public class Module : IModule
    {
        IUnityContainer unityContainer;

        public Module(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        public void Initialize()
        {
            this.unityContainer.RegisterInstance<IEmailService>(new EmailService());
        }
    }
}
