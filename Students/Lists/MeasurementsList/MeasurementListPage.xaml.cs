using Students.Add.AddMeasurements;
using Students.Delete.DeleteMeasurements;
using Students.Edit.EditMeasurements;
using Students.Entities;
using Students.Lists.StudentList;

namespace Students.Lists.MeasurementsList
{
    public partial class MeasurementListPage : ContentPage
    {
        private MainPageViewModel _mpvm;
        private Student _student;

        public MeasurementListPage(MainPageViewModel mpvm, Student student)
        {
            this._mpvm = mpvm;
            this._student = student;
            InitializeComponent();
            BindingContext = new MeasurementListPageViewModel(_student);
            JsonFileHandler.SaveData(this._mpvm.Groups);
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMeasurementPage(_mpvm, _student));
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteMeasurementPage(_mpvm, _student));
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditMeasurementPage(_mpvm, _student));
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {

            var d = (MeasurementListPageViewModel)BindingContext;
            if (d.MeasurementOfStudents.Last() != null)
            {
                d.MeasurementOfStudents.Last().CalcLevel();
                _student.Level = d.MeasurementOfStudents.Last().Level;
            }

            await Navigation.PushAsync(new StudentListPage(_mpvm));
        }

        protected override bool OnBackButtonPressed()
        {
            var d = (MeasurementListPageViewModel)BindingContext;
            if (d.MeasurementOfStudents.Last() != null)
            {
                d.MeasurementOfStudents.Last().CalcLevel();
                _student.Level = d.MeasurementOfStudents.Last().Level;
            }

            Navigation.PushAsync(new StudentListPage(_mpvm));
            return true;
        }
    }
}