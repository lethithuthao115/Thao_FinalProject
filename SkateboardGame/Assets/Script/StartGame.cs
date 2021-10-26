using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += (arg0, mode) =>
        {
            //if (GameManager.Instance != null)
            //    GameManager.Instance.SetNumberItem();
        };
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("MainScene");
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
    }
}