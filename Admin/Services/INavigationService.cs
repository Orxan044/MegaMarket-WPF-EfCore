using Admin.Models.Abstract;
using System.Windows.Controls;

namespace Admin.Services;

public interface INavigationService
{
    void Navigate<TView, TViewModel>() where TView : Page where TViewModel : BaseViewModel;

}
