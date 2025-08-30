using System.Windows;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace Wpf.Ui.Views.Windows;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        SystemThemeWatcher.Watch(this);
        ApplicationThemeManager.ApplySystemTheme();
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        RootNavigation.Navigate("Home");
    }

    private void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        RootNavigation.SetCurrentValue(NavigationView.IsPaneOpenProperty, e.NewSize.Width > 950);
    }
}