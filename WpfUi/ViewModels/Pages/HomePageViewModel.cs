using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Views.Windows;

namespace WpfUi.ViewModels.Pages;

public partial class HomePageViewModel : ObservableObject
{
    [RelayCommand]
    private void NavigateToSetting()
    {
        var mainClass = (MainWindow)Application.Current.MainWindow;
        mainClass!.RootNavigation.Navigate("Setting");
    }
}