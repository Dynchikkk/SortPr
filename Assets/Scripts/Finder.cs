using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour
{
    public Line finderLine;

    private int _neededLine;

    public void FindByName(string name)
    {
        var allLines = Logic.main.lineList;

        for (int i = 0; i < allLines.Count; i++)
        {
            if(allLines[i].nameField.text == name)
            {
                _neededLine = i;
                break;
            }
        }

        SetFinderLine();
    }

    public void SetFinderLine()
    {
        Line needLine = Logic.main.lineList[_neededLine];
        finderLine.number.text = needLine.lineNum.ToString();
        finderLine.dateField.text = needLine.dateField.text;
        finderLine.nameField.text = needLine.nameField.text;
        finderLine.broughtField.text = needLine.broughtField.text;
        finderLine.takenField.text = needLine.takenField.text;
        finderLine.leftField.text = needLine.leftField.text;
    }
}
