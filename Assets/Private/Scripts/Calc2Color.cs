using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calc2Color
{
    public static List<string> keyList = new List<string>()
    {
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "x", "="
    };

    public static List<Color> colorList = new List<Color>()
    {
        new Color(0f, 0f, 0f, 1f),  //"black"
        new Color(0.83f, 0.68f, 0f, 1f),  //"yellow"
        new Color(0f, 0f, 0f, 0.5f),  //"none"
        new Color(1f, 0.63f, 0.95f, 1f),  //"pink"
        new Color(1f, 0f, 0f, 1f),  //"red"
        new Color(0.13f, 0.7f, 0f, 1f),  //"green"
        new Color(0f, 0f, 0f, 0.5f),  //"none"
        new Color(0f, 0.3f, 1.0f, 1f),  //"blue"
        new Color(0.45f, 0.26f, 0.16f, 1f),  //"brown"
        new Color(1f, 0.46f, 0f, 1f),  //"orange"
        new Color(1f, 1f, 1f, 1f),  //"white"
        new Color(0.5f, 0f, 0.8f, 1f),  //"purple"
        new Color(0.45f, 0.45f, 0.45f, 1f),  //"gray"
    };

    public static Color getColorValue(string key)
    {
        for (int i = 0; i < colorList.Count; i++)
        {
            if (keyList[i] == key)
            {
                if (key == "2" || key == "6")
                {
                    Debug.LogError("key " + key + " is not implemented");
                }

                return colorList[i];
            }
        }

        Debug.Log("not found color");
        return new Color(0f, 0f, 0f, 0.5f);
    }

}
