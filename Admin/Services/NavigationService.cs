using Admin.Models.Abstract;
using System.Windows.Controls;

namespace Admin.Services;

public class NavigationService : INavigationService
{
    public void Navigate<TView, TViewModel>() where TView : Page where TViewModel : BaseViewModel
    {
        //var mainVm1 = System.Windows.Application.Current.MainWindow.DataContext as MainViewModel;
        //if (mainVm1 is not null)
        //{
        //    mainVm1!.CurrentPage = App.MainContainer.GetInstance<TView>();
        //    mainVm1.CurrentPage.DataContext = App.MainContainer.GetInstance<TViewModel>();

        //}
    }
}
