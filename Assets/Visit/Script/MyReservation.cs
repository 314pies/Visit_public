using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


public class MyReservationInfo
{
    public int ID;
    public string Time;
}

public class MyReservation : MonoBehaviour
{

    public BoothsDB boothsDB;
    public Transform cardRoot;

    public static List<MyReservationInfo> myReservationInfos = new List<MyReservationInfo>() {
        //new MyReservationInfo() { ID = 1, Time = "10:00~12:00" },
        //new MyReservationInfo() { ID = 2, Time = "10:00~12:00" },
        //new MyReservationInfo() { ID = 3, Time = "10:00~12:00" },
        //new MyReservationInfo() { ID = 4, Time = "10:00~12:00" },
        //new MyReservationInfo() { ID = 5, Time = "10:00~12:00" },
        //new MyReservationInfo() { ID = 6, Time = "10:00~12:00" },
    };


    public ResultBoothCard[] AllCards;
    public void OnEnable()
    {

        //AllCards = cardRoot.GetComponentsInChildren<ResultBoothCard>();


        for (int i = 0; i < AllCards.Length; i++)
        {
            var _info = boothsDB.Booths[i];
            AllCards[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < myReservationInfos.Count && i < 8; i++)
        {
            //Debug.Log(i);
            AllCards[i].gameObject.SetActive(true);
            var boothID = myReservationInfos[i].ID;
            var _info = boothsDB.Booths[boothID];

            var timeSlot = myReservationInfos[i].Time;

            AllCards[i].SetInfo(_info.logo, _info.name, _info.Location, timeSlot, boothID);
            double timeAdd = UnityEngine.Random.Range(1, 100) > 50 ? 30 : 45;
        }

        for (int i = 0; i < AllCards.Length; i++)
        {
            if (!AllCards[i].isActiveAndEnabled)
            {
                AllCards[i].transform.SetAsLastSibling();
            }
        }
    }
}
