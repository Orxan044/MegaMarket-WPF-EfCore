using Mega_Market.Models.Abstract;
using System.Windows.Controls;

namespace Mega_Market.Services.Navigate;

public interface INavigationService
{
    void Navigate<TView, TViewModel>(Page? CurrentPage) where TView : Page where TViewModel : BaseViewModel;

}
