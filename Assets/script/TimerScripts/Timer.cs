using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTxt;
    float timeLeft;
    // Update is called once per frame
    void Update()
    {
        timeLeft += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int secondes = Mathf.FloorToInt(timeLeft % 60);
        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, secondes);
    }
}
