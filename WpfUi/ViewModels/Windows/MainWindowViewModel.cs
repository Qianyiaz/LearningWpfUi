using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Appearance;

namespace Wpf.Ui.Views.Pages.ViewModels.Windows;

public partial class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel()
    {
        ApplicationThemeManager.Changed += (theme, _) => IsChecked = theme == ApplicationTheme.Dark;
    }

    [ObservableProperty] private string _assemblyName = "Wpf Ui";
    [ObservableProperty] private bool _isChecked;

    [RelayCommand]
    private void ChangeTheme()
    {
        ApplicationThemeManager.Apply(ApplicationThemeManager.GetAppTheme() == ApplicationTheme.Dark
            ? ApplicationTheme.Light
            : ApplicationTheme.Dark);
    }
}