using Students.Lists.MeasurementsList;
using Students.Lists.StudentList;

namespace Students.Delete.DeleteStudent
{
    public partial class DeleteStudentPage : ContentPage
    {
        private MainPageViewModel _mpvm;

        public DeleteStudentPage(MainPageViewModel mpvm)
        {
            this._mpvm = mpvm;
            InitializeComponent();
            BindingContext = new DeleteStudentPageViewModel(_mpvm.SelectedGroup);
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (DeleteStudentPageViewModel)BindingContext;
            if (viewModel.SelectedStudent != null)
            {
                viewModel.DeleteStudent(viewModel.SelectedStudent);
                viewModel.SelectedStudent = null;
            }
          
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