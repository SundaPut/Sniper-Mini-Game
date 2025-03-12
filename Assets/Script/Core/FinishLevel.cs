using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public void Finish()
    {
        //Save new level
        PlayerPrefs.SetInt("currentScene", PlayerPrefs.GetInt("currentScene") + 1);

        //Load main menu
        SceneManager.LoadScene("Map");
    }

    public void TryAgain()
    {
        // Memuat ulang scene saat ini
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
