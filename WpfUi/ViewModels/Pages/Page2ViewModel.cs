using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfUi.ViewModels.Pages;

public partial class Page2ViewModel : ObservableObject
{
    [ObservableProperty] private Visibility _cardVisibility = Visibility.Visible;

    [ObservableProperty]
    private string _inputUrl = "https://learn.microsoft.com/zh-cn/microsoft-edge/webview2/get-started/wpf";

    [ObservableProperty] private string _url;

    public Page2ViewModel()
    {
        Url = InputUrl;
    }

    partial void OnUrlChanged(string value)
    {
        InputUrl = value;
    }

    partial void OnInputUrlChanged(string value)
    {
        if (Uri.TryCreate(value, UriKind.Absolute, out var uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            Url = value!;
    }

    [RelayCommand]
    private void Hide()
    {
        CardVisibility = Visibility.Collapsed;
    }
}