using UnityEngine;
using UnityEngine.SceneManagement;

public class winscreen : MonoBehaviour
{
    public winscreen Winscreen;

    public void RestartButton()
    {
        SceneManager.LoadScene("game");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("menu");

    }

}
