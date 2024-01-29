namespace Students.Add.AddGroup
{
    public partial class AddGroupPage : ContentPage
    {
        private MainPageViewModel _mpvm;

        public AddGroupPage(MainPageViewModel mpvm)
        {
            this._mpvm = mpvm;
            InitializeComponent();

            BindingContext = new AddGroupPageViewModel(_mpvm.Groups);
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (AddGroupPageViewModel)BindingContext;
            viewModel.AddGroup();

            await Navigation.PushAsync(new MainPage(_mpvm));
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new MainPage(_mpvm));
            return true;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(_mpvm));
        }
    }
}