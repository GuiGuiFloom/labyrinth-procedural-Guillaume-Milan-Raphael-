using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextOnStart : MonoBehaviour
{
    public TextMeshProUGUI TextStart;



    //; coroutine qui lance un timer pour que le text u debut ne saffiche que pendant un moment
    IEnumerator TextOStart()
    {
        yield return new WaitForSeconds(0.2f);

        /*GameObject.Find("TextDebut").SetActive(false);*/
        GameObject.Find("TextDebut").transform.position = new Vector3(-1000, 0, 0);

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
