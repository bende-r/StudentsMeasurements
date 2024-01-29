using Students.Lists.MeasurementsList;
using Students.Lists.StudentList;

namespace Students.Edit.EditStudent
{
    public partial class EditStudentPage : ContentPage
    {
        private MainPageViewModel _mpvm;

        public EditStudentPage(MainPageViewModel mpvm)
        {
            this._mpvm = mpvm;
            InitializeComponent();
            BindingContext = new EditStudentPageViewModel(_mpvm.SelectedGroup);
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