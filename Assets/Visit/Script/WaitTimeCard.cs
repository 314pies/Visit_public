using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaitTimeCard : MonoBehaviour
{

    public Image logo;
    public TMP_Text BoothName, Locatio, WaitTime;

    public int ID;

    public void SetInfo(Sprite logo, string boothName, string Location, string waitLine, int ID)
    {
        this.logo.sprite = logo;
        BoothName.text = boothName;
        Locatio.text = "Location: " + Location;
        WaitTime.text = waitLine;
        this.ID = ID;
    }
}
