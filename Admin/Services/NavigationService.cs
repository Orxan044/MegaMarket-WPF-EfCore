using Admin.Models.Abstract;
using Admin.ViewModels;
using System.Windows.Controls;

namespace Admin.Services;

public class NavigationService : INavigationService
{
    public void Navigate<TView, TViewModel>() where TView : Page where TViewModel : BaseViewModel
    {
        var mainVm = System.Windows.Application.Current.MainWindow.DataContext as MainViewModel;
        if (mainVm is not null)
        {
            mainVm!.CurrentPage = App.Container.GetInstance<TView>();
            mainVm.CurrentPage.DataContext = App.Container.GetInstance<TViewModel>();

        }
    }
}
