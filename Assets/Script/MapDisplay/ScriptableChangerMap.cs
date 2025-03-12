using UnityEngine;

public class ScriptableChangerMap : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] scriptableObjects;

    [Header("Display Scripts")]
    [SerializeField] private MapDisplay mapDisplay;
    private int currentMapIndex;

    public void Start()
    {
        currentMapIndex = SaveManager.Instance.currentMap;
        ChangeMap(0);
    }

    public void ChangeMap(int _index)
    {
        currentMapIndex += _index;
        if (currentMapIndex < 0) currentMapIndex = scriptableObjects.Length - 1;
        if (currentMapIndex > scriptableObjects.Length - 1) currentMapIndex = 0;

        if (mapDisplay != null) mapDisplay.DisplayMap((Map)scriptableObjects[currentMapIndex]);

        SaveManager.Instance.currentMap = currentMapIndex;
        SaveManager.Instance.Save();
    }
}