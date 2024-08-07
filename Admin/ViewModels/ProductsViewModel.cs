using Admin.Command;
using Admin.Data;
using Admin.Data.Repositories;
using Admin.Models.Abstract;
using Admin.Models.Concretes;
using Admin.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace Admin.ViewModels;

public class ProductsViewModel : BaseViewModel , INotifyPropertyChanged
{
    private string? _searchText;
    private ICollectionView _productsView;

    public Product product { get; set; } = new();

    public string SearchText
    {
        get => _searchText!;
        set
        {
            _searchText = value;
            OnPropertyChanged();
            _productsView.Refresh();
        }
    }

    private MenyuViewModel _menyuViewModel;

    public RelayCommand ShowProductCommand { get; set; }
    public RelayCommand AddProductCommand { get; set; }
    
    private ObservableCollection<Product>? _products;
    public ObservableCollection<Product> Products { get => _products!; set { _products = value; OnPropertyChanged(); } }

    private readonly IRepository<Product,MarketDbContext> _productRepository;
    public ProductsViewModel(IRepository<Product,MarketDbContext> productRepository, MenyuViewModel menyuViewModel)
    {
        _menyuViewModel = menyuViewModel;
        _productRepository = productRepository;
        Products = new ObservableCollection<Product>(_productRepository.GetAll());


        ShowProductCommand = new RelayCommand(ShowProductClick);
        AddProductCommand = new RelayCommand(AddProductClick);

        _productsView = CollectionViewSource.GetDefaultView(Products);
        _productsView.Filter = FilterCategories;
    }

    private void AddProductClick(object? obj)
    {
        //
    }

    private void ShowProductClick(object? id)
    {
        if (id is not null)
        {
            product = _productRepository.Get(Convert.ToInt32(id))!;
            _menyuViewModel.ShowProductClick(id);
            var mainVm = App.Current.MainWindow.DataContext as MainViewModel;
            if (mainVm is not null)
            {
                var vm = _menyuViewModel.CurrentPage2!.DataContext as ProductShowViewModel;
                vm!.SelectedProduct = product.Clone();
                vm.SelectedCategory = product.Category!;
            }
        }     
    }

    private bool FilterCategories(object obj)
    {
        if (obj is Product product)
        {
            return string.IsNullOrEmpty(SearchText) || product.Name!.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
            product.Id.ToString()!.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
        }
        
        return false;
    }



    #region INotifyPropertyChanged event
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    #endregion







}
