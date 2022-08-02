using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSection : MonoBehaviour
{
    public void NewSection()
    {
        Logic localMain = Logic.main;

        GameObject newSec = Instantiate(localMain.sectionPref.gameObject, localMain.sectionParent.transform);
        newSec.name = localMain.sectionsList.Count + newSec.name;
        Section current = newSec.GetComponent<Section>();

        current.sectionNum = localMain.sectionsList.Count + 1;

        localMain.sectionsList.Add(current);
    }
}
