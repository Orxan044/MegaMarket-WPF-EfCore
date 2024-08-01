using Admin.Data;
using Admin.Data.Repositories;
using Admin.Services;
using Admin.ViewModels;
using Admin.Views;
using SimpleInjector;
using System.Windows;

namespace Admin;

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
        Container.RegisterSingleton<AdminDbContext>();
        Container.RegisterSingleton<IRepository<Models.Concretes.Admin, AdminDbContext>, Repository<Models.Concretes.Admin, AdminDbContext>>();
        Container.RegisterSingleton<INavigationService, NavigationService>();
    }

    private static void AddViewModels()
    {
        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<LoginViewModel>();
        Container.RegisterSingleton<MenyuViewModel>();
    }

    private static void AddViews()
    {
        Container.RegisterSingleton<MainView>();
        Container.RegisterSingleton<LoginView>();
        Container.RegisterSingleton<MenyuView>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainView = Container.GetInstance<MainView>();
        mainView.DataContext = Container.GetInstance<MainViewModel>();
        mainView.Show();
        base.OnStartup(e);
    }
}
