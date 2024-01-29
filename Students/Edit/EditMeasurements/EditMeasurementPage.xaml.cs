using Students.Entities;
using Students.Lists.MeasurementsList;

namespace Students.Edit.EditMeasurements
{
    public partial class EditMeasurementPage : ContentPage
    {
        private MainPageViewModel _mpvm;
        private Student _student;
      
        public EditMeasurementPage(MainPageViewModel mpvm, Student student)
        {
            this._mpvm = mpvm;
            this._student = student;
            InitializeComponent();
            BindingContext = new EditMeasurementPageViewModel(_student);
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