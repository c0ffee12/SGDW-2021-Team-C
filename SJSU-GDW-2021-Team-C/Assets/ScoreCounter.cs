using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    public Text text;

    public void Start()
    {
        text = GetComponent<Text>();
        formatText(Score.money);
    }

    public void ChangeMoney(float money)
    {
        Score.money += money;
        formatText(Score.money);
    }

    public void formatText(float money)
    {
        text.text = string.Format("{0:C2}", money / 100);
        
    }

}

public static class Score
{
    public static float money = 0f;
}