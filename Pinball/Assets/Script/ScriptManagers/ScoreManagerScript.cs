using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManagerScript : MonoBehaviour
{
    public static int  score = 0;
    public TextMeshPro display;
    void Update()
    {
        if (display)
        {
            display.text = score.ToString("D8");
        }
    }
}
