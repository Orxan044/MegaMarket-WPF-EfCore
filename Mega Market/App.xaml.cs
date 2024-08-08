using Mega_Market.Services.Navigate;
using Mega_Market.ViewModel;
using Mega_Market.Views;
using SimpleInjector;
using System.Windows;

namespace Mega_Market;

public partial class App : Application
{
    public static Container Container { get; set; } = new();
    public App()
    {
        AddOtherServices();
        AddViews();
        AddViewModels();
    }
    private static void AddOtherServices()
    {
        Container.RegisterSingleton<INavigationService,NavigateServices>();
    }

    private static void AddViewModels()
    {
        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<SplashViewModel>();
    }

    private static void AddViews()
    {
        Container.RegisterSingleton<MainView>();
        Container.RegisterSingleton<SplashView>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        //MainViewModel mv = new MainViewModel();
        //mv.WindowWitdh = 450;
        //mv.WindowHeight = 750;
        var mainView = Container.GetInstance<MainView>();
        mainView.DataContext = Container.GetInstance<MainViewModel>();
        mainView.Show();
        base.OnStartup(e);
    }

}
