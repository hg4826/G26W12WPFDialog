using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace G26W12WPFDialog;

public partial class MainViewModel(Func<Gundam?> showDialog) : ObservableObject {
    [ObservableProperty]
    private string _resultText = "";

    [RelayCommand]
    private void Add() {
        if (showDialog() is not { } item) return;

        ResultText += $"{item.Faction}의 {item.Model} {
            item.Name.WithSubject()
            } 추가되었습니다.\n";
    }
}
