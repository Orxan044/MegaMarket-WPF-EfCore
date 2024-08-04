using Admin.Command;
using Admin.Models.Abstract;
using Admin.Services;
using Admin.Views;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Admin.ViewModels;

public class MenyuViewModel : BaseViewModel, INotifyPropertyChanged
{
    private Page? _currentPage2;

    public Page? CurrentPage2 { get => _currentPage2; set { _currentPage2 = value; OnPropertyChanged(); } }

    #region RelayCommand
    public RelayCommand DashBoardCommand { get; set; }
    public RelayCommand ExitCommand { get; set; }
    #endregion


    private readonly INavigationService _navigationService;
    public MenyuViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        #region RelayCommand
        DashBoardCommand = new RelayCommand(DashBoardClick);
        ExitCommand = new RelayCommand(ExitClick);
        #endregion

        _currentPage2 = App.Container.GetInstance<DashBoardView>();
        _currentPage2.DataContext = App.Container.GetInstance<DashBoardViewModel>();
    }

    private void ExitClick(object? obj)
    {
        Application.Current.MainWindow.Close();
        Environment.Exit(0);
    }

    private void DashBoardClick(object? obj)
    {
        _currentPage2 = App.Container.GetInstance<DashBoardView>();
        _currentPage2.DataContext = App.Container.GetInstance<DashBoardViewModel>();
    }


    #region INotifyPropertyChanged event
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    #endregion
}
