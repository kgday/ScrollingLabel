using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using ScrollingLabel.Views;

using Splat;

namespace ScrollingLabel
{
    public class App : Application
    {
        static App()
        {
            IOC = new IOC();
            IOC.RegisterDependencies();
        }

        private static IOC IOC { get; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = IOC.GetService<MainWindow>();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}