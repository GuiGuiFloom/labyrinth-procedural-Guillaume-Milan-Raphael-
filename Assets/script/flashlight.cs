using UnityEngine;
using UnityEngine.UI;


public class flashlight : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject torch;
    [SerializeField] private float battery = 100f;
    [SerializeField] private float batteryDepletionSpeed = 0.7f;
    [SerializeField] private KeyCode SwtichKey = KeyCode.F;
    public GameObject player;
    private bool on;

    [Header("UI")]
    [SerializeField] private Text batterytext;

    private void Update()
    {
        if (Input.GetKeyDown(SwtichKey))
        { on = !on;
            
        }

        if (on && battery > 0)
            battery -= batteryDepletionSpeed * Time.deltaTime;
        else if (battery < 0.01f)
            on = false;

        batterytext.text = $"Battery: {(int)battery}";

        torch.SetActive(on);

        //player death
        if (on && battery > 0)
            battery -= batteryDepletionSpeed * Time.deltaTime;
        else if (battery < 0.01f)

            // to modify  for full game (disable les controles du joueur
            Destroy(player.gameObject); 

    }
}
