using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finder : MonoBehaviour
{
    public GameObject finderLinesParent;

    private int _neededLine;
    public List<Line> _findedLines = new List<Line>();
    public List<Line> _spawnsLine = new List<Line>();
    Logic localMain;

    private void Start()
    {
        localMain = Logic.main;
    }

    public void FindByName(string name)
    {
        ClearList();

        var allLines = Logic.main.lineList;

        for (int i = 0; i < allLines.Count; i++)
        {
            if(allLines[i].nameField.text == name)
            {
                _findedLines.Add(allLines[i]);
            }
        }

        if (name == "")
        {
            _findedLines.Clear();
        }

        SpawnFindedLines();
    }

    public void AddFindedLine()
    {
        // Создаем линию
        GameObject newLine = Instantiate(localMain.linePref.gameObject, finderLinesParent.transform);
        newLine.name = _spawnsLine.Count + newLine.name;
        Line current = newLine.GetComponent<Line>();

        // Добавляем линию в список со всеми линиями
        current.lineNum = _spawnsLine.Count + 1;

        // Присваиваем номер
        _spawnsLine.Add(current);
    }

    public void SpawnFindedLines()
    {
        if (_findedLines.Count <= 0)
        {
            localMain.SetConditionToList(true);
            finderLinesParent.SetActive(false);
            return;
        }

        localMain.SetConditionToList(false);
        finderLinesParent.SetActive(true);

        for (int i = 0; i < _findedLines.Count; i++)
        {
            AddFindedLine();
        }

        for (int i = 0; i < _spawnsLine.Count; i++)
        { 
            LineContent localLine = _findedLines[i].currentLine;

            _spawnsLine[i].SetParam(localLine.date, localLine.name,
                localLine.brought, localLine.taken, localLine.left);
        }
    }

    public void ClearList()
    {
        _findedLines.Clear();

        for (int i = 0; i < _spawnsLine.Count; i++)
        {
            Destroy(_spawnsLine[i].gameObject);
        }

        _spawnsLine.Clear();
    }
}
