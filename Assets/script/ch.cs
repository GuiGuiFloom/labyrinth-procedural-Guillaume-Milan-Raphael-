using System.Reflection.Metadata.Ecma335;
using UnityEngine;

public class ch : MonoBehaviour
{

    CharacterController chara;

    Vector3 move_speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chara = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        move_speed = new Vector3(Input.GetAxis(""), 0, Input.GetAxis(""));
        chara.SimpleMove(move_speed);

    }
}
