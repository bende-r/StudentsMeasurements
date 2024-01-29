using Students.Lists.MeasurementsList;
using Students.Lists.StudentList;

namespace Students.Add.AddStudent
{
    public partial class AddStudentPage : ContentPage
    {
        private MainPageViewModel _mpvm;
        private string _gender;

        public AddStudentPage(MainPageViewModel mpvm)
        {
            this._mpvm = mpvm;
            InitializeComponent();
            BindingContext = new AddStudentPageViewModel(_mpvm.SelectedGroup);
        }

        private void OnGenderPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            _gender = (string)picker.SelectedItem;
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (AddStudentPageViewModel)BindingContext;
            viewModel.NewGender = _gender;
            viewModel.AddStudent();

            await Navigation.PushAsync(new StudentListPage(_mpvm));
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentListPage(_mpvm));
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new StudentListPage(_mpvm));
            return true;
        }
    }
}