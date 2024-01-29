namespace Students.Delete.DeleteGroup
{
    public partial class DeleteGroupPage : ContentPage
    {
        private MainPageViewModel _mpvm;

        public DeleteGroupPage(MainPageViewModel mpvm)
        {
            this._mpvm = mpvm;
            InitializeComponent(); NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new DeleteGroupPageViewModel(_mpvm.Groups);
        }
 private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (DeleteGroupPageViewModel)BindingContext;
            if (viewModel.SelectedGroup != null)
            {
                viewModel.DeleteGroup(viewModel.SelectedGroup);
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