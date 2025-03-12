using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void NextScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}