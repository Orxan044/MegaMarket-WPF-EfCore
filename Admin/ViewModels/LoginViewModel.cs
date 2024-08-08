using Admin.Command;
using Admin.Data.Repositories;
using Admin.Data;
using Admin.Models.Abstract;
using Admin.Services;
using System.Windows;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using Admin.Views;

namespace Admin.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IRepository<Models.Concretes.Admin, AdminDbContext> _adminRepository;

    public RelayCommand CloseCommand { get; set; }
    public RelayCommand SignInCommand { get; set; }
    public RelayCommand SignUpCommand { get; set; }
    public Models.Concretes.Admin AdminLogin { get; set; } = new();
    public LoginViewModel(IRepository<Models.Concretes.Admin, AdminDbContext> adminRepository, INavigationService navigationService)
    {
        _adminRepository = adminRepository;
        _navigationService = navigationService;

        CloseCommand = new RelayCommand(CloseClik);
        SignInCommand = new RelayCommand(SignInClick);
        SignUpCommand = new RelayCommand(SignUpClick);
    }

    private void SignUpClick(object? obj)
    {
        throw new NotImplementedException();
    }


    private void SignInClick(object? obj)
    {
        var Admins = _adminRepository.GetAll();
        bool checking = true;
        foreach (var admin in Admins)
        {
            if(AdminLogin.AccountName  == admin.AccountName 
               && AdminLogin.AccountPassword == admin.AccountPassword)
            {
                notifier.ShowSuccess("You Are Logged In Correctly");
                checking = false;
                MainViewModel mainVm = new();
                _navigationService.Navigate<MenyuView, MenyuViewModel>(mainVm.CurrentPage);
            }
        }

        if(checking) notifier.ShowError("Please Login Correctly !!!");
    }

    private void CloseClik(object? obj)
    {
        Application.Current.MainWindow.Close();
        Environment.Exit(0);
    }


}
