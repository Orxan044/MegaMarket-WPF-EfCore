using Admin.Models.Abstract;
using Admin.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ToastNotifications.Core;

namespace Admin.ViewModels;

public class MainViewModel : BaseViewModel , INotifyPropertyChanged
{
    private Page? _currentPage;
    public Page? CurrentPage { get => _currentPage; set { _currentPage = value; OnPropertyChanged(); }  }

    public MainViewModel()
    {
        _currentPage = App.Container.GetInstance<MenyuView>();
        _currentPage.DataContext = App.Container.GetInstance<MenyuViewModel>();
    }




    #region INotifyPropertyChanged event
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    #endregion
}
