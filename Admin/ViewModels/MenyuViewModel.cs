using Admin.Command;
using Admin.Data;
using Admin.Models.Abstract;
using Admin.Models.Concretes;
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

    private readonly MarketDbContext _marketDbContext; 

    #region RelayCommand
    public RelayCommand DashBoardCommand { get; set; }
    public RelayCommand CategoriesCommand { get; set; }
    public RelayCommand ProductsCommand { get; set; }
    public RelayCommand ExitCommand { get; set; }
    #endregion


    private readonly INavigationService _navigationService;
    public MenyuViewModel(INavigationService navigationService, MarketDbContext marketDbContext)
    {
        _marketDbContext = marketDbContext;
        _navigationService = navigationService;

        #region RelayCommand
        DashBoardCommand = new RelayCommand(DashBoardClick);
        CategoriesCommand = new RelayCommand(CategoriesClick);
        ProductsCommand = new RelayCommand(ProductsClick);
        ExitCommand = new RelayCommand(ExitClick);
        #endregion

        CurrentPage2 = App.Container.GetInstance<DashBoardView>();
        CurrentPage2.DataContext = App.Container.GetInstance<DashBoardViewModel>();
    }
    private void DashBoardClick(object? obj)
    {
        CurrentPage2 = App.Container.GetInstance<DashBoardView>();
        CurrentPage2.DataContext = App.Container.GetInstance<DashBoardViewModel>();
    }

    public void CategoriesClick(object? obj)
    {
        CurrentPage2 = App.Container.GetInstance<CategoryView>();
        CurrentPage2.DataContext = App.Container.GetInstance<CategoryViewModel>();
    }
        
    private void ProductsClick(object? obj)
    {
        CurrentPage2 = App.Container.GetInstance<ProductsView>();
        CurrentPage2.DataContext = App.Container.GetInstance<ProductsViewModel>();
    }

    private void ExitClick(object? obj)
    {
        _marketDbContext.SaveChanges();
        Application.Current.MainWindow.Close();
        Environment.Exit(0);
    }


    #region INotifyPropertyChanged event
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    #endregion
}
