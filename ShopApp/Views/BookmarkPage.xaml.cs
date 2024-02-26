using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class BookmarkPage : ContentPage
{
    public BookmarkPage(BookmarkViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
