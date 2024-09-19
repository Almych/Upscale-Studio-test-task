
using UnityEngine;
using TMPro;

public class TImerCount : MonoBehaviour
{
    private TextMeshProUGUI timerUi => GetComponent<TextMeshProUGUI>();
    private float counter;

    
    void Update()
    {
        counter += Time.deltaTime;
        ShowTime(counter);
    }

    private void ShowTime (float timer)
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        timerUi.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
