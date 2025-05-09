using UnityEngine;
using TMPro;


public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        int hours = (int)(elapsedTime / 3600);
        int minutes = (int)((elapsedTime % 3600) / 60);
        int seconds = (int)(elapsedTime % 60);

        timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
    }
}
