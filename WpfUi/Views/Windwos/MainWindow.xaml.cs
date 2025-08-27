using System.Windows;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using Wpf.Ui.Views.Pages.ViewModels.Windows;

namespace Wpf.Ui.Views.Windows;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        SystemThemeWatcher.Watch(this);
        ApplicationThemeManager.Changed += (theme, _) =>
        {
            var vm = (MainWindowViewModel)DataContext;
            vm.IsChecked = theme == ApplicationTheme.Dark;
        };
        ApplicationThemeManager.ApplySystemTheme();
        SizeChanged += (_, args) =>
        {
            RootNavigation.SetCurrentValue(NavigationView.IsPaneOpenProperty, args.NewSize.Width > 950);
        };
        RootNavigation.Navigate("Home");
    }
}