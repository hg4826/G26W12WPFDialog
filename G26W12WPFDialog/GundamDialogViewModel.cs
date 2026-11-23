using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace G26W12WPFDialog;

public partial class GundamDialogViewModel : ObservableObject {
    public string[] Factions { get; } = ["연방군", "지온군", "기타"];

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(OkCommand))]
    private string _name = "";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(OkCommand))]
    private string _model = "";

    [ObservableProperty]
    private string _faction = "연방군";

    public Gundam? Result { get; private set; }
    public event Action<bool>? CloseRequested;

    // 이름과 모델이 둘 다 채워졌을 때만 true 반환
    private bool CanOk() =>
        !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Model);

    // CanOk가 true일 때만 enabled (활성화됨)
    // 함수 이름 뒤에 Command를 붙여서 OkCommand 자동 생성
    [RelayCommand(CanExecute = nameof(CanOk))]
    private void Ok() {
        Result = new(Name.Trim(), Model.Trim(), Faction);
        CloseRequested?.Invoke(true);
    }

    [RelayCommand]
    private void Cancel() => CloseRequested?.Invoke(false);
}
