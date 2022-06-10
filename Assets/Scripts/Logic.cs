using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public static Logic main;

    [Header("Lines")]
    public List<Line> lineList = new List<Line>();
    public Line linePref;
    public GameObject lineParent;

    [Header("Another")]
    [SerializeField]
    private CreateButton _creater;

    private Saver _saverCopy;

    private void Awake()
    {
        main = this;
        _saverCopy = Camera.main.GetComponent<Saver>();
    }

    private void Start()
    {
        UseSavedData();
    }

    public void UseSavedData()
    {
        for (int i = 0; i < _saverCopy.LineListToSave.Count; i++)
        {
            _creater.NewLine();
        }

        for (int i = 0; i < lineList.Count; i++)
        {
            var locList = _saverCopy.LineListToSave[i];
            lineList[i].SetParam(locList.currentLine.date, locList.currentLine.name, 
                locList.currentLine.brought, locList.currentLine.taken, locList.currentLine.left);
        }
    }

    public void PrepareToSave()
    {
        foreach (var item in lineList)
        {
            _saverCopy.LineListToSave.Add(item);
        }

        _saverCopy.SaveGame();
    }
}
