using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultBoothCard : MonoBehaviour
{
    public Image logo;
    public TMP_Text BoothName, Locatio, ReserveTimeSlot;

    public int boothID;

    public void SetInfo(Sprite logo, string boothName, string Location, string timeSlot, int ID)
    {
        this.logo.sprite = logo;
        BoothName.text = boothName;
        Locatio.text = "" + Location;
        ReserveTimeSlot.text = timeSlot;
        boothID = ID;
    }
}
