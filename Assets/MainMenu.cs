using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float XMoveTo = 20f;
    public float YMoveTo = 0f;
    public float XMoveTime = 10f;
    public float YMoveTime = .2f;
    public Vector3 defaultScale = new Vector3(1, 1, 1);
    public Vector3 ScaleTo = new Vector3(2,2,2);
    public float ScaleTime = .5f;

    [SerializeField] GameObject startButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject titletxt;

    private void Start()
    {
        LeanTween.scaleY(titletxt, 1.25f, ScaleTime).setLoopPingPong();
        LeanTween.rotateZ(titletxt, -5f, 1f).setLoopPingPong();
    }

    public void StartPressed()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2Pressed()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ReturnToMenuPressed()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitPressed()
    {
        Application.Quit();
    }

    public void GrowStartButton()
    {
        LeanTween.scale(startButton, ScaleTo, ScaleTime).setLoopPingPong();
    }

    public void StopGrowStartButton()
    {
        startButton.transform.localScale = defaultScale;
        LeanTween.cancel(startButton);
    }

    public void GrowQuitButton()
    {
        LeanTween.scale(quitButton, ScaleTo, ScaleTime).setLoopPingPong();
    }

    public void StopGrowQuitButton()
    {
        quitButton.transform.localScale = defaultScale;
        LeanTween.cancel(quitButton);
    }
}
