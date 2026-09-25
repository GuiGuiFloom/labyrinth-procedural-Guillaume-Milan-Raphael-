using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameOverScript : MonoBehaviour
{

    /*public Text pointsText;*/
    /*public TextMeshProUGUI GameOver;*/

    public void Start()
    {
        GameObject.Find("GameOverScreen").SetActive(false);
    }
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void GameOver()
    {
        GameObject.Find("GameOverScreen").SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    internal void Setup(int noBattery)
    {
        throw new NotImplementedException();
    }
}
