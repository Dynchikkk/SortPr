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

    public void MoveToPar()
    {

    }
}

[Serializable]
public class Par
{
    public int num;
    public string name;
    public List<Line> parLines = new List<Line>();
}
