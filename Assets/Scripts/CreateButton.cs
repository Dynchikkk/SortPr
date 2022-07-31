using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour
{
    public void NewLine()
    {
        Logic localMain = Logic.main;

        // Создаем линию
        GameObject newLine = Instantiate(localMain.linePref.gameObject, localMain.lineParent.transform);
        newLine.name = localMain.lastSection.parContent.parLines.Count + newLine.name;
        Line current = newLine.GetComponent<Line>();

        current.lineNum = localMain.lastSection.parContent.parLines.Count + 1;

        localMain.lastSection.parContent.parLines.Add(current);
    }
}
