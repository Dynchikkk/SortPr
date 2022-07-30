﻿using System.Collections;
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
        newLine.name = localMain.lineList.Count + newLine.name;
        Line current = newLine.GetComponent<Line>();

        // Добавляем линию в список со всеми линиями
        current.lineNum = localMain.lineList.Count + 1;

        // Присваиваем номер
        localMain.lineList.Add(current);
    }
}
