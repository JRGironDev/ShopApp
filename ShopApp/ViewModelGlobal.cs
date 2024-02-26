using CommunityToolkit.Mvvm.ComponentModel;

namespace ShopApp;
public partial class ViewModelGlobal : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    public bool IsNotBusy => !IsBusy;

}

