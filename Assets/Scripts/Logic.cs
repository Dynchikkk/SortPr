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
    public CreateButton creater;
    public Button saveButton;

    [Header("Section Atribute")]
    public List<Section> sectionsList = new List<Section>();
    public Section sectionPref;
    public GameObject sectionParent;

    [Header("Another")]
    public GameObject Par;
    public GameObject InPar;
    public Section lastSection;

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
            creater.NewLine();
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
        creater.gameObject.SetActive(condition);
        saveButton.gameObject.SetActive(condition);
    }

    //True - par, False - in par
    public void ChangeMainWorkSpace(bool condition)
    {
        switch(condition)
        {
            case true:
                Par.transform.Translate(1090, 0, 0, Space.Self);
                InPar.transform.Translate(1090, 0, 0, Space.Self);
                break;

            case false:
                Par.transform.Translate(-1090, 0, 0, Space.Self);
                InPar.transform.Translate(-1090, 0, 0, Space.Self);
                break;

            //default:
            //    Debug.LogError("Failed to change work space");
            //    break;
        }
    }
}
