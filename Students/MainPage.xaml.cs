using System.Collections.ObjectModel;

using Students.Add.AddGroup;
using Students.Delete.DeleteGroup;
using Students.Edit.EditGroup;
using Students.Entities;
using Students.Lists.StudentList;

namespace Students;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _mainPageViewModel = new MainPageViewModel();

    public MainPage()
    {
        InitializeComponent(); NavigationPage.SetHasNavigationBar(this, false);
        BindingContext = _mainPageViewModel;
        ObservableCollection<Group> groups = JsonFileHandler.LoadData();
        if (groups != null)
            _mainPageViewModel.Groups = JsonFileHandler.LoadData();
    }

    public MainPage(MainPageViewModel mpvm)
    {
        InitializeComponent();
        _mainPageViewModel = mpvm;
        BindingContext = mpvm;
        JsonFileHandler.SaveData(_mainPageViewModel.Groups);
    }

    private async void ShowStudentsPage(object sender, EventArgs e)
    {
        var viewModel = _mainPageViewModel;
        if (viewModel.SelectedGroup != null)
        {
            await Navigation.PushAsync(new StudentListPage(_mainPageViewModel));
        }
    }

    private async void AddGroupClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddGroupPage(_mainPageViewModel));
    }

    private async void DeleteGroupClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DeleteGroupPage(_mainPageViewModel));
    }

    private async void EditGroupClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditGroupPage(_mainPageViewModel));
    }

    //private void Button_OnClicked(object sender, EventArgs e)
    //{
    //    JsonFileHandler.SaveData(_mainPageViewModel.Groups);
    //}
}