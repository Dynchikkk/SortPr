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

        SetParam(currentLine.date, currentLine.name, currentLine.brought, currentLine.taken, currentLine.left);
    }

    public void CalculateLeft()
    {
        if (broughtField.text == "" || takenField.text == "")
            return;

        int res = Convert.ToInt32(broughtField.text) - Convert.ToInt32(takenField.text);
        leftField.text = res.ToString();
    }

    // Выставляем текст в инпуте
    public void SetText()
    {
        int? br = currentLine.brought;
        int? tk = currentLine.taken;
        int? lf = currentLine.left;

        if (currentLine.date != null)
            dateField.text = currentLine.date.ToString();

        if(currentLine.name != null)
            nameField.text = currentLine.name.ToString();

        if (br != null)
            broughtField.text = currentLine.brought.ToString();


        if (tk != null)
            takenField.text = currentLine.taken.ToString();


        if (lf != null)
            leftField.text = currentLine.left.ToString();
    }

    // Получаем параметры
    public void SetParam(string date, string name, int brought, int taken, int left)
    {
        currentLine.date = date;
        currentLine.name = name;
        currentLine.brought = brought;
        currentLine.taken = taken;
        currentLine.left = left;

        SetText();
    }

    // Получаем текст из инпута
    public void SetParamFromInput(Line cur)
    {
        int br, tk, lf;
        Int32.TryParse(cur.broughtField.text, out br);
        Int32.TryParse(cur.takenField.text, out tk);
        Int32.TryParse(cur.leftField.text, out lf);

        SetParam(cur.dateField.text,
            cur.nameField.text, br, tk, lf);
    }

    public void ReformDate(Line cur)
    {
        TMP_InputField df = cur.dateField;
        switch (df.text.Length)
        {
            case 2:
                df.text += ".";
                df.stringPosition += 1;
                break;

            case 5:
                df.text += ".";
                df.stringPosition += 1;
                break;

            default:
                break;
        }
    }
}

[Serializable]
public class LineContent
{
    public string date;
    public string name;
    public int brought;
    public int taken;
    public int left;
}
