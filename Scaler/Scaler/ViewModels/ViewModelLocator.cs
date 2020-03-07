﻿using CommonServiceLocator;
using Scaler.Startup;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            Startup.Startup.Initialize();
        }

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();
    }
}
