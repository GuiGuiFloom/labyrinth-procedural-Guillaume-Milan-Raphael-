using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextOnStart : MonoBehaviour
{
    public TextMeshProUGUI TextStart;



    //; coroutine qui lance un timer pour que le text u debut ne saffiche que pendant un moment(2 secondes ici)
    IEnumerator TextOStart()
    {
        yield return new WaitForSeconds(2f);

        GameObject.Find("Text du debut").SetActive(false);
        
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //.Afficher un message au debut du jeu
        StartCoroutine(TextOStart());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
