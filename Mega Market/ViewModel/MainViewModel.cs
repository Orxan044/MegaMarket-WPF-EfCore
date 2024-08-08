using Mega_Market.Models.Abstract;
using Mega_Market.Views;
using System.ComponentModel;
using System.Windows.Controls;

namespace Mega_Market.ViewModel;

public class MainViewModel : BaseViewModel , INotifyPropertyChanged
{

    private double _windowHeight;

    public double WindowHeight
    {
        get => _windowHeight; 
        set { _windowHeight = value; OnPropertyChanged(); }
    }

    private double _windowWidth;

    public double WindowWitdh
    {
        get => _windowWidth;
        set { _windowWidth = value; OnPropertyChanged(); }
    }


    private Page? _currentPage;
    public Page? CurrentPage { get => _currentPage; set { _currentPage = value; OnPropertyChanged(); } }
    public MainViewModel()
    {
        WindowWitdh = 450; 
        WindowHeight = 750;
        _currentPage = App.Container.GetInstance<SplashView>();
        _currentPage.DataContext = App.Container.GetInstance<SplashViewModel>();
    }
}
