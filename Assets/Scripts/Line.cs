using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Line : MonoBehaviour
{
    public int lineNum;
    public LineContent currentLine;

    [Header("LineCell")]
    public TMP_Text number;
    public TMP_InputField dateField;
    public TMP_InputField nameField;
    public TMP_InputField broughtField;
    public TMP_InputField takenField;
    public TMP_InputField leftField;

    public void Start()
    {
        number.text = lineNum.ToString();
    }

    public void CalculateLeft()
    {
        if (broughtField.text == "" || takenField.text == "")
            return;

        int res = Convert.ToInt32(broughtField.text) - Convert.ToInt32(takenField.text);
        leftField.text = res.ToString();
    }
}

[System.Serializable]
public class LineContent
{
    public string date;
    public string name;
    public int brought;
    public int taken;
    public int left;
}
