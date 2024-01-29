namespace Students.Edit.EditGroup
{
    public partial class EditGroupPage : ContentPage
    {
        private MainPageViewModel _mpvm;

        public EditGroupPage(MainPageViewModel mpvm)
        {
            _mpvm = mpvm;
            InitializeComponent(); NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new EditGroupViewModel(mpvm.Groups);
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (EditGroupViewModel)BindingContext;
            if (viewModel.SelectedGroup != null)
            {
                viewModel.UpdateGroup(viewModel.SelectedGroup);
                viewModel.SelectedGroup = null;
            }
        }
        
        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(_mpvm));
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new MainPage(_mpvm));
            return true;
        }
    }
}