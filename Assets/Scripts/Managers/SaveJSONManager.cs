using UnityEngine;
using System.IO;

public class SaveJSONManager : MonoBehaviour
{
    public static SaveJSONManager saveJSONManager;
    public MyData data;

    void Start()
    {
        // ������������ � JSON
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);

        // �������������� �� JSON
        MyData loadedData = JsonUtility.FromJson<MyData>(json);
        Debug.Log(loadedData.saveName + ", " + loadedData.age);

        // ���������� � ����
        File.WriteAllText(Application.persistentDataPath + "/" + data.saveName + ".json", json);
    }

    public void LoadSave()
    {
        string loadedJson = File.ReadAllText(Application.persistentDataPath + "/data.json");
        MyData loadedFromFile = JsonUtility.FromJson<MyData>(loadedJson);
        Debug.Log(loadedFromFile.saveName + ", " + loadedFromFile.age);
    }

    [System.Serializable]
    public class MyData
    {
        public string saveName;
        public int age;
    }
}