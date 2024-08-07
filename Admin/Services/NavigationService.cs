using Admin.Data;
using Admin.Data.Repositories;
using Admin.Models.Abstract;
using Admin.Models.Concretes;
using Admin.ViewModels;
using System.Windows.Controls;

namespace Admin.Services;

public class NavigationService : INavigationService
{
    public void Navigate<TView, TViewModel>(Page? CurrentPage) where TView : Page where TViewModel : BaseViewModel
    {
        var mainVm = System.Windows.Application.Current.MainWindow.DataContext as MainViewModel;
        var mainVm2 = System.Windows.Application.Current.MainWindow.DataContext as MenyuViewModel;
        if (mainVm is not null)
        {
            mainVm!.CurrentPage = App.Container.GetInstance<TView>();
            mainVm.CurrentPage.DataContext = App.Container.GetInstance<TViewModel>();
        }
        if(mainVm2 is not null)
        {  
            mainVm2!.CurrentPage2 = App.Container.GetInstance<TView>();
            mainVm2.CurrentPage2.DataContext = App.Container.GetInstance<TViewModel>();
        }
    }
}
