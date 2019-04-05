using System.Windows;
using School.BL;

namespace School.App
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            InitializeAutoMapper();
            base.OnStartup(e);
        }

        private void InitializeAutoMapper()
        {
            new MapperInitializer().Initialize();
        }
    }
}