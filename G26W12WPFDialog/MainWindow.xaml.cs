using System.Windows;

namespace G26W12WPFDialog;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    public void OnAdd(object sender, RoutedEventArgs e) {
        GundamDialogViewModel viewModel = new();
        GundamDlg dialog = new(viewModel) { Owner = this };
        if (dialog.ShowDialog() != true || viewModel.Result is not { } item)
            return;

        ResultText.Text += $"{item.Faction}의 {item.Model} {
            item.Name.WithSubject()
            } 추가되었습니다.\n";
    }
}
