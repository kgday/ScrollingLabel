using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using ScrollingLabel.ViewModels;
using ReactiveUI;
using Avalonia.ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace ScrollingLabel.Views
{
    public class MainWindow : ReactiveWindow<IMainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated(d =>
            {
                DataContext = ViewModel;

                //router bound in xaml
                ViewModel?
                  .Load
                  .Execute()
                  .Subscribe()
                  .DisposeWith(d);
            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
