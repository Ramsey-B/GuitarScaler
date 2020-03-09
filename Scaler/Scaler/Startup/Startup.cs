using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Scaler.Business.Interfaces;
using Scaler.Business.Services;
using Scaler.Data.Interfaces;
using Scaler.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Startup
{
    public sealed class Startup
    {
        public static void Initialize()
        {
            try
            {
                var containerBuilder = new ContainerBuilder();
                RegisterViewModels(ref containerBuilder);
                RegisterServices(ref containerBuilder);
                RegisterRepositories(ref containerBuilder);
                var container = containerBuilder.Build();

                var serviceLocator = new AutofacServiceLocator(container);
                ServiceLocator.SetLocatorProvider(() => serviceLocator);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static void RegisterViewModels(ref ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MainViewModel>().AsSelf();
        }

        private static void RegisterServices(ref ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ChordService>().As<IChordService>().SingleInstance();
            containerBuilder.RegisterType<ScaleService>().As<IScaleService>().SingleInstance();
            containerBuilder.RegisterType<NeckService>().As<INeckService>().SingleInstance();
        }

        private static void RegisterRepositories(ref ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TuningRepository>().As<ITuningRepository>().SingleInstance();
            containerBuilder.RegisterType<NotesRepository>().As<INoteRepository>().SingleInstance();
            containerBuilder.RegisterType<ScaleRepository>().As<IScaleRepository>().SingleInstance();
        }
    }
}
