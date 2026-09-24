using System.Collections;
using UnityEditor;
using UnityEngine;

public class spawn : MonoBehaviour
{

    //. Couroutine permettant d'appeller la fonction build apres un timer ert qui relance la coroutine a chaque fois que celle ci se termine 
    IEnumerator compteur()
    {
        yield return new WaitForSeconds(5);
        GameObject.Find("Maze Generator").GetComponent<MazeGenerator>().build();
        StartCoroutine(compteur());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //. lance le timer
        StartCoroutine(compteur());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
