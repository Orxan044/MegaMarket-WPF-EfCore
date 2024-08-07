using Admin.Command;
using Admin.Data.Repositories;
using Admin.Data;
using Admin.Models.Abstract;
using Admin.Models.Concretes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;

namespace Admin.ViewModels;

public class AddCategoryViewModel : BaseViewModel , INotifyPropertyChanged
{
    private Category? newCategory;
	public Category NewCategory
	{
		get => newCategory!; 
		set { newCategory = value; OnPropertyChanged(); }
	}

    MenyuViewModel _viewModel;
    private readonly IRepository<Category, MarketDbContext> _categoryRepository;

    public RelayCommand AddCategoryCommand { get; set; }
    public RelayCommand BackCommand { get; set; }
    
	public AddCategoryViewModel(IRepository<Category, MarketDbContext> categoryRepository,MenyuViewModel viewModel)
    {
        _viewModel = viewModel;
        _categoryRepository = categoryRepository;
        NewCategory = new();
        AddCategoryCommand = new RelayCommand(AddCategoryClick);
        BackCommand = new RelayCommand(BackClick);
    }

    private void BackClick(object? obj)
    {
        _viewModel.CategoriesClick(obj);
    }

    private void AddCategoryClick(object? obj)
    {
        if(NewCategory.Name is not null)
        {
            _categoryRepository.Add(NewCategory);
            _categoryRepository.SaveChanges();
            notifier.ShowSuccess("The Category Has Been Adding Successfully");
            NewCategory = new();
        }
        else notifier.ShowError("New Category Name Cannot be Null !!!");
    }


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


    #region INotifyPropertyChanged event
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    #endregion
}
