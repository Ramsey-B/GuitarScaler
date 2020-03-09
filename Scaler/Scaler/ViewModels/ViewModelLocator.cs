using CommonServiceLocator;

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
