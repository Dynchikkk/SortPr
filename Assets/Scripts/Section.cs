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

    public void Start()
    {
        number.text = parContent.num.ToString();
        _localLogic = Logic.main;
    }

    public void MoveToPar()
    {
        _localLogic.ChangeMainWorkSpace(false);
        _localLogic.lastSection = this;

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
            LineContent lineFather = parContent.parLines[i].currentLine;
            current.SetParam(lineFather.date, lineFather.name, lineFather.brought,
                lineFather.taken, lineFather.left);
        }
    }
}

[Serializable]
public class Par
{
    public int num;
    public string name;
    public List<Line> parLines = new List<Line>();
}
