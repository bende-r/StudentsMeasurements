using Students.Entities;
using Students.Lists.MeasurementsList;

namespace Students.Add.AddMeasurements
{
    public partial class AddMeasurementPage : ContentPage
    {
        private MainPageViewModel _mpvm;
        private Student _student;

        private string _rate;

        public AddMeasurementPage(MainPageViewModel mpvm, Student student)
        {
            this._mpvm = mpvm;
            this._student = student;

            InitializeComponent();
            BindingContext = new AddMeasurementPageViewModel(student);
        }

  private void OnRatePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            _rate = (string)picker.SelectedItem;
        }

  private async void AddButton_Clicked(object sender, EventArgs e)
        {
            var viewModel = (AddMeasurementPageViewModel)BindingContext;
            viewModel.NewHeartRateMin = _rate;
            viewModel.AddMeasurement();

            await Navigation.PushAsync(new MeasurementListPage(_mpvm, _student));
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