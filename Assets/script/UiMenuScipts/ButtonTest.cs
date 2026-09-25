using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class ButtonTest : MonoBehaviour
{

   

    public TextMeshProUGUI numbers;

    //. quannd le button est pressé sur l'ui sa lance la scene principale du jeu 
    public void ButtonPressed()
    {

        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
