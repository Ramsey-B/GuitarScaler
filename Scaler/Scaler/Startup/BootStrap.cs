using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Scaler.Business.Interfaces;
using Scaler.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Startup
{
    public sealed class BootStrap
    {
        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterViewModels(ref containerBuilder);
            RegisterServices(ref containerBuilder);
            var container = containerBuilder.Build();

            var serviceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        private static void RegisterViewModels(ref ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MainViewModel>().AsSelf();
        }

        private static void RegisterServices(ref ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ChordService>().As<IChordService>().SingleInstance();
        }
    }
}
