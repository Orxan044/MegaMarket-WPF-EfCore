using Admin.Models.Abstract;
using System.Windows.Controls;

namespace Admin.Services;

public interface INavigationService
{
    void Navigate<TView, TViewModel>(Page? CurrentPage) where TView : Page where TViewModel : BaseViewModel;

}
