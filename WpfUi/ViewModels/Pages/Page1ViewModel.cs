using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Wpf.Ui.ViewModels.Pages;

public partial class Page1ViewModel : ObservableObject
{
    [ObservableProperty]
    private List<string> _autoSuggestBoxSuggestions =
    [
        "The cake is lie.",
        "It's so boring.",
        "I don't think so.",
        "Say everything about you."
    ];
}