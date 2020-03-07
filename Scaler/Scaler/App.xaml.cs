using Autofac;
using Autofac.Core;
using Scaler.Business.Interfaces;
using Scaler.Business.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Scaler
{
    public partial class App : Application
    {
        public static IContainer Container;
        public App()
        {
            InitializeComponent();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ChordService>().As<IChordService>().SingleInstance();
            Container = containerBuilder.Build();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
