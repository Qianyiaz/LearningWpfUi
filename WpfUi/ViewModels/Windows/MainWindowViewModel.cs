using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using Wpf.Ui.Views.Windows;

namespace Wpf.Ui.Views.Pages.ViewModels.Windows;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private bool _isChecked;

    public MainWindowViewModel()
    {
        ApplicationThemeManager.Changed += (theme, _) =>
        {
            IsChecked = theme == ApplicationTheme.Dark;
        };
        ApplicationThemeManager.ApplySystemTheme();

        var mainClass = (MainWindow)Application.Current.MainWindow;
        mainClass!.Loaded += (_, _) =>
        {
            SystemThemeWatcher.Watch(mainClass);
            mainClass.RootNavigation.Navigate("Home");
        };
        mainClass.SizeChanged += (_, e) =>
        {
            mainClass.RootNavigation.SetCurrentValue(NavigationView.IsPaneOpenProperty, e.NewSize.Width > 950);
        };
    }

    [RelayCommand]
    private void ChangeTheme() =>
        ApplicationThemeManager.Apply(ApplicationThemeManager.GetAppTheme() == ApplicationTheme.Dark ? ApplicationTheme.Light : ApplicationTheme.Dark);
}