using UnityEngine;
using System.IO;

public class OrnamentPosition : MonoBehaviour
{
    private Ornament _attachedOrnament;
    private OrnamentData _attachedOrnamentData;
    public string filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "Saves.json");

    public OrnamentData AttachedOrnamentData
    {
        get
        {
            return _attachedOrnamentData;
        }
        set
        {
            _attachedOrnamentData = value;
            Ornament ornamentPrefab = Resources.Load<Ornament>("Ornaments/" + _attachedOrnamentData.prefab);
            _attachedOrnament = Instantiate(ornamentPrefab, this.transform);
            _attachedOrnament.SetMaterial(Resources.Load<Material>("Materials/" + _attachedOrnamentData.material));
            _attachedOrnament.text = _attachedOrnamentData.text;

            //string json = JsonUtility.ToJson(_attachedOrnamentData);
            //string jsonContnent = File.ReadAllText(filePath);
            //jsonContnent += json;
            //File.WriteAllText(filePath, jsonContnent);

            //PlayerPrefs.SetString(gameObject.name, json);
            //PlayerPrefs.Save();
            //Debug.Log(json);
        }
    }

    public bool HasOrnament => _attachedOrnamentData != null;

    public void RemoveOrnament()
    {
        _attachedOrnamentData = null;
        Destroy(_attachedOrnament.gameObject);
    }
}