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

    // Anonther
    private int prevLength;
    private Logic _localLogic;
    private int _prevLeft;

    public void Start()
    {
        _localLogic = Logic.main;

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

    public void SetPrevLeft()
    {
        _prevLeft = Convert.ToInt32(leftField.text);
    }

    public void SetLeftToSection()
    {
        _localLogic.lastSection.parContent.left += (Convert.ToInt32(broughtField.text) - Convert.ToInt32(takenField.text)) - _prevLeft;
        _localLogic.lastSection.SetTextToLeft();
    }

    // Выставляем текст в инпуте
    public void SetText()
    {
        int? br = currentLine.brought;
        int? tk = currentLine.taken;
        int? lf = currentLine.left;

        if (currentLine.date != null)
            dateField.text = currentLine.date.ToString();

        if (currentLine.name != null)
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
        string dfText = df.text;
        if (dfText.Length > 0)
        {
            df.onValueChanged.RemoveAllListeners();
            if (!char.IsDigit(dfText[dfText.Length - 1]) && dfText[dfText.Length - 1] != '/')
            { // Remove Letters
                df.text = dfText.Remove(dfText.Length - 1);
                df.caretPosition = df.text.Length;
            }
            else if (dfText.Length == 2 || dfText.Length == 5)
            {
                if (dfText.Length < prevLength)
                { // Delete
                    df.text = dfText.Remove(dfText.Length - 1);
                    df.caretPosition = df.text.Length;
                }
                else
                { // Add
                    df.text = dfText + "/";
                    df.caretPosition = df.text.Length;
                }
            }
        }
        prevLength = df.text.Length;
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
