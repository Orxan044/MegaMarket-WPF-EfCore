using Admin.Command;
using Admin.Data;
using Admin.Data.Repositories;
using Admin.Models.Abstract;
using Admin.Models.Concretes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace Admin.ViewModels;

public class ProductShowViewModel : BaseViewModel , INotifyPropertyChanged
{
    private Product? _selectedProduct;
    private Category? selectedCategory;
    private MenyuViewModel _viewModel;
    private IRepository<Product, MarketDbContext> _productRepository;

    public  Product SelectedProduct { get => _selectedProduct!; set { _selectedProduct = value; OnPropertyChanged(); }}
    public Category SelectedCategory { get => selectedCategory!; set { selectedCategory = value; OnPropertyChanged(); } }

    
    public ObservableCollection<Category> Categories { get; set; }
    
    public RelayCommand BackCommand { get; set; }
    public RelayCommand UpdateCommand { get; set; }
    public RelayCommand DeleteCommand { get; set; }


    public ProductShowViewModel(CategoryViewModel categoryVM, MenyuViewModel viewModel,IRepository<Product,MarketDbContext> productRepository)
    {
        _productRepository = productRepository;
        _viewModel = viewModel;
        Categories = categoryVM.Categories;
        BackCommand = new RelayCommand(BackClick);
        UpdateCommand = new RelayCommand(UpdateClick);
        DeleteCommand = new RelayCommand(DeleteClick);
    }

    private void DeleteClick(object? obj)
    {
        _productRepository.Delete(SelectedProduct);
        _productRepository.SaveChanges();
        notifier.ShowSuccess("The Product Has Been Remove Successfully !!!");
        _viewModel.ProductsClick(obj);
    }

    private void UpdateClick(object? obj)
    {
        //if (SelectedProduct.Category != SelectedCategory)
        //{
        //    _productRepository.Update(SelectedProduct);
        //    _productRepository.SaveChanges();
        //    notifier.ShowSuccess("The Product Has Been Updated Successfully !!!");
        //    _viewModel.ProductsClick(obj);
        //}
        //else notifier.ShowWarning("The Elements Are All The Same !!!");
        try
        {
            ProductsViewModel productsViewModel = new(_productRepository,_viewModel);
            _productRepository.Update(productsViewModel.product);
            _productRepository.SaveChanges();
            notifier.ShowSuccess("The Product Has Been Updated Successfully !!!");
            _viewModel.ProductsClick(obj);

        }
        catch (Exception)
        {
            notifier.ShowWarning("The Elements Are All The Same !!!");
        }
    }

    private void BackClick(object? obj)
    {
        _viewModel.ProductsClick(obj);
    }




    #region INotifyPropertyChanged event
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    #endregion

    #region Create notifier
    ToastNotifications.Notifier notifier = new ToastNotifications.Notifier(cfg =>
    {
        cfg.PositionProvider = new WindowPositionProvider(
            parentWindow: Application.Current.MainWindow,
            corner: Corner.TopLeft,
            offsetX: 5,
            offsetY: 5);

        cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
            notificationLifetime: TimeSpan.FromSeconds(2),
            maximumNotificationCount: MaximumNotificationCount.FromCount(1));

        cfg.Dispatcher = Application.Current.Dispatcher;
    });
    #endregion
}
