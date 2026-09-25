using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject exitblock;
    public GameObject Player;


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            //finish screen
        }
        
    }

}
