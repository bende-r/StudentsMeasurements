using System.Collections.ObjectModel;
using System.ComponentModel;
using Students.Entities;

namespace Students.Add.AddGroup;

public class AddGroupPageViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Group> _groupsList;

    public AddGroupPageViewModel(ObservableCollection<Group> groupsList)
    {
        this._groupsList = groupsList;
    }

    private string _newGroupName;

    public string NewGroupName
    {
        get => _newGroupName;
        set
        {
            _newGroupName = value;
            OnPropertyChanged(nameof(NewGroupName));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void AddGroup()
    {
        if (NewGroupName!=null && !NewGroupName.Equals(string.Empty))
        {
            Group group = new Group()
            {
                Name = NewGroupName
            };

            _groupsList.Add(group);

            NewGroupName = string.Empty;
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}