
using System.Collections.Generic;
using UnityEngine;

public class ChristmasTree : MonoBehaviour
{
    [SerializeField] private List<Transform> ornamentPositions = new List<Transform>();
    [SerializeField] private List<Material> ornamentMaterials = new List<Material>();
    [SerializeField] private List<Ornament> ornamentPrefabs;

    private void Start()
    {
        foreach (var ornamentPositionTransform in ornamentPositions)
        {
            OrnamentPosition ornamentPosition = ornamentPositionTransform.gameObject.AddComponent<OrnamentPosition>();
            
            if(PlayerPrefs.HasKey(ornamentPosition.name))
            {
                string json = PlayerPrefs.GetString(ornamentPosition.name);
                OrnamentData ornamentData = JsonUtility.FromJson<OrnamentData>(json);
                ornamentPosition.AttachedOrnamentData = ornamentData;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SaveToJson();
        }
    }

    public void SaveToJson()
    {
        SaveData save = new SaveData();

        for(int i = 0; i < ornamentPositions.Count; i++)
        {
            save.ornaments.Add(ornamentPositions[i].GetComponent<OrnamentPosition>().AttachedOrnamentData);
        }

        string json = JsonUtility.ToJson(save);

        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string filePath = System.IO.Path.Combine(desktopPath, "Saves.json");
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, json);
        Debug.Log("Saved to Desktop at: " + filePath);
    }

}