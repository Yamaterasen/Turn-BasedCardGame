using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;

    public void StartPressed()
    {
        SceneManager.LoadScene("CardGame");
    }

    public void QuitPressed()
    {
        Application.Quit();
    }
}
