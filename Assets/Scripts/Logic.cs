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

    [Header("Finder Atribute")]
    [SerializeField]
    private CreateButton _creater;
    public Button saveButton;

    [Header("Section Atribute")]
    public List<Section> sectionsList = new List<Section>();
    public Section sectionPref;
    public GameObject sectionParent;

    private Saver _saverCopy;

    private void Awake()
    {
        main = this;
        _saverCopy = Camera.main.GetComponent<Saver>();
    }

    private void Start()
    {
        //UseSavedData();
    }

    public void UseSavedData()
    {
        for (int i = 0; i < _saverCopy.lineListToSave.Count; i++)
        {
            _creater.NewLine();
        }

        for (int i = 0; i < lineList.Count; i++)
        {
            var locList = _saverCopy.lineListToSave[i];
            lineList[i].SetParam(locList.date, locList.name, 
                locList.brought, locList.taken, locList.left);
        }
    }

    public void PrepareToSave()
    {
        _saverCopy.lineListToSave.Clear();
        foreach (var item in lineList)
        {
            _saverCopy.lineListToSave.Add(item.currentLine);
        }

        _saverCopy.SaveGame();
    }

    public void SetConditionToList(bool condition)
    {
        lineParent.SetActive(condition);
        _creater.gameObject.SetActive(condition);
        saveButton.gameObject.SetActive(condition);
    }
}
