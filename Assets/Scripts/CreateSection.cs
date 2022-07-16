using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSection : MonoBehaviour
{
    Logic localMain;

    private void Awake()
    {
        localMain = Logic.main;
    }

    public void NewSection()
    {
        GameObject newSec = Instantiate(localMain.sectionPref.gameObject, localMain.sectionParent.transform);
        newSec.name = localMain.sectionsList.Count + newSec.name;
        Section current = newSec.GetComponent<Section>();

        current.parContent.num = localMain.sectionsList.Count + 1;

        localMain.sectionsList.Add(current);
    }
}
