using Students.Add.AddStudent;
using Students.Delete.DeleteMeasurements;
using Students.Delete.DeleteStudent;
using Students.Edit.EditMeasurements;
using Students.Edit.EditStudent;
using Students.Entities;
using Students.Lists.MeasurementsList;


namespace Students.Lists.StudentList
{
    public partial class StudentListPage : ContentPage
    {
        private MainPageViewModel _mpvm;
        private Group _group;
        private Student _student;

        public StudentListPage(MainPageViewModel mpvm)
        {
            this._mpvm = mpvm;
            this._group = mpvm.SelectedGroup;
            InitializeComponent();
            BindingContext = new StudentListPageViewModel(_mpvm.SelectedGroup);
            JsonFileHandler.SaveData(this._mpvm.Groups);
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddStudentPage(_mpvm));
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteStudentPage(_mpvm));
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditStudentPage(_mpvm));
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

        private async void MeasurementsListButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (StudentListPageViewModel)BindingContext;
            if (viewModel.SelectedStudent != null)
            {
                await Navigation.PushAsync(new MeasurementListPage(_mpvm, viewModel.SelectedStudent));
            }
        }
    }
}