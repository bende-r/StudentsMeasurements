using Students.Entities;
using Students.Lists.MeasurementsList;

namespace Students.Delete.DeleteMeasurements
{
    public partial class DeleteMeasurementPage : ContentPage
    {
        private MainPageViewModel _mpvm;
        private Student _student;

        public DeleteMeasurementPage(MainPageViewModel mpvm, Student student)
        {
            this._mpvm = mpvm;
            this._student = student;
            InitializeComponent();
            BindingContext = new DeleteMeasurementPageViewModel(_student);
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (DeleteMeasurementPageViewModel)BindingContext;
            if (viewModel.SelectedMeasurementOfStudent != null)
            {
                viewModel.DeleteMeasurement(viewModel.SelectedMeasurementOfStudent);
                viewModel.SelectedMeasurementOfStudent = null;
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MeasurementListPage(_mpvm, _student));
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new MeasurementListPage(_mpvm, _student));
            return true;
        }
    }
}