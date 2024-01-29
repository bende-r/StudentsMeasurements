using System.Collections.ObjectModel;

using Newtonsoft.Json;

using Students.Entities;

using Formatting = System.Xml.Formatting;

namespace Students;

public class JsonFileHandler
{
    public static void SerializeHotelsToFile(ObservableCollection<Group> groups, string filePath)
    {
        string json = JsonConvert.SerializeObject(groups, (Newtonsoft.Json.Formatting)Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public static ObservableCollection<Group> DeserializeHotelsFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<ObservableCollection<Group>>(json);
        }
        return new ObservableCollection<Group>();
    }

    public static void SaveData(ObservableCollection<Group> groups)
    {
        string fileName = "StudentsMeasurement.json";
        string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "StudentsApp");
        Directory.CreateDirectory(directory);

        string filePath = Path.Combine(directory, fileName);

        SerializeHotelsToFile(groups, filePath);
    }

    public static ObservableCollection<Group> LoadData()
    {
        string fileName = "StudentsMeasurement.json";
        string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "StudentsApp");
        string filePath = Path.Combine(directory, fileName);
        return DeserializeHotelsFromFile(filePath);
    }
}