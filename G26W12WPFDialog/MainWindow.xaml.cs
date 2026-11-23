using System.Windows;

namespace G26W12WPFDialog;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

        DataContext = new MainViewModel(() => {
            var viewModel = new GundamDialogViewModel();
            var dialog = new GundamDlg(viewModel) { Owner = this };
            return dialog.ShowDialog() == true ? viewModel.Result : null;
        });
    }
}
