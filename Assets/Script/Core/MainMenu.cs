using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMwnu;
    [SerializeField] private GameObject settings;

    private void Start()
    {
        mainMwnu.SetActive(true);
        settings.SetActive(false);
    }

    public void Update()
    {
        
    }

    public void MoveToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Mainmenu()
    {
        mainMwnu.SetActive(true);
        settings.SetActive(false);
    }

    public void Settings()
    {
        mainMwnu.SetActive(false);
        settings.SetActive(true);

    }
}
