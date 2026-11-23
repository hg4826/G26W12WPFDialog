using System.Windows;

namespace G26W12WPFDialog;

public partial class GundamDlg : Window {
    public GundamDlg(GundamDialogViewModel viewModel) {
        InitializeComponent();

        DataContext = viewModel;
        viewModel.CloseRequested += OnCloseRequested;
        Closed += (_, _) => viewModel.CloseRequested -= OnCloseRequested;
    }

    private void OnCloseRequested(bool accepted) => DialogResult = accepted;
}
