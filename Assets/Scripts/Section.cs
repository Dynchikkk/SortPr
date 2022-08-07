using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Section : MonoBehaviour
{
    public Par parContent;

    public TMP_Text number;
    public TMP_InputField parName;
    public Button toPar;

    private Logic _localLogic;

    public int sectionNum;

    public void Start()
    {
        number.text = sectionNum.ToString();
        _localLogic = Logic.main;
    }

    public void MoveToPar()
    {
        _localLogic.ChangeMainWorkSpace(false);
        _localLogic.lastSection = this;

        _localLogic.sectionNameText.text = parContent.name;

        // Destroy old lines
        int cC = _localLogic.lineParent.transform.childCount;
        for (int i = 0; i < cC; i++)
        {
            Destroy(_localLogic.lineParent.transform.GetChild(i).gameObject);
        }

        // Create new lines
        for (int i = 0; i < parContent.parLines.Count; i++)
        {
            // Создаем линию
            GameObject newLine = Instantiate(_localLogic.linePref.gameObject, _localLogic.lineParent.transform);
            newLine.name = i + newLine.name;
            Line current = newLine.GetComponent<Line>();
            current.lineNum = i + 1;

            // Задаем параметры линии
            LineContent lineFather = parContent.parLines[i];
            current.SetParam(lineFather.date, lineFather.name, lineFather.brought,
                lineFather.taken, lineFather.left);
        }
    }

    public void SetParamToPar(string name, List<LineContent> parLinesContent)
    {
        parContent.name = name;
        for (int i = 0; i < parLinesContent.Count; i++)
        {
            parContent.parLines.Add(parLinesContent[i]);
        }

        SetText();
    }

    public void SetText()
    {
        if (parContent.name != null)
        {
            parName.text = parContent.name;
        }
    }

    public void SetParamFromInput(Section current)
    {
        parContent.name = current.parName.text;

        SetText();
    }

    public void SetTextToLeft()
    {
        _localLogic.sectionLeftText.text = parContent.left.ToString();
    }
}

[Serializable]
public class Par
{
    public string name;
    public int left;
    public List<LineContent> parLines = new List<LineContent>();
}
