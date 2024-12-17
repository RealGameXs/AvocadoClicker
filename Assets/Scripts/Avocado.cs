using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Advacado : MonoBehaviour
{
    int score = 0;//getal
    public TMP_Text scoreboard;//text

    //method
    public void incermentscore()
    {
        score++;
        scoreboard.text = score.ToString();
    }

}
    