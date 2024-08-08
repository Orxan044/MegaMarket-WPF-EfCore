using Mega_Market.Models.Abstract;
using Mega_Market.ViewModel;
using System.Windows.Controls;

namespace Mega_Market.Services.Navigate;

public class NavigateServices : INavigationService
{

    public void Navigate<TView, TViewModel>(Page? CurrentPage) where TView : Page where TViewModel : BaseViewModel
    {
        var mainVm = System.Windows.Application.Current.MainWindow.DataContext as MainViewModel;
        if (mainVm is not null)
        {
            //mainVm!.CurrentPage = App.Container.GetInstance<TView>();
            //mainVm.CurrentPage.DataContext = App.Container.GetInstance<TViewModel>();
        }
    }
}
