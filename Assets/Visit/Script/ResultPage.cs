using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ResultPage : MonoBehaviour
{

    public BoothsDB boothsDB;
    public Transform cardRoot;

    public BookVisit_TimeOfStay BookVisit_TimeOfStay;

    public void OnEnable()
    {

        var AllCards = cardRoot.GetComponentsInChildren<ResultBoothCard>();
        
        var _start = BookVisit_TimeOfStay.Start.text;
        var _end = BookVisit_TimeOfStay.End.text;

        DateTime startDateTime = DateTime.ParseExact(_start, "HH:mm",
                                        CultureInfo.InvariantCulture);
        DateTime endDateTime = DateTime.ParseExact(_end, "HH:mm",
                                       CultureInfo.InvariantCulture);

        Debug.Log(startDateTime);
        Debug.Log(endDateTime);


        for (int i = 0; i < AllCards.Length; i++)
        {
            var _info = boothsDB.Booths[i];
            AllCards[i].gameObject.SetActive(false);
        }

        var visitStartTime = startDateTime;
        for (int i = 0; i < SelectBoothManager.singleTon.selectedBooth.Count && i < 8; i++)
        {
            AllCards[i].gameObject.SetActive(true);
            var boothID = SelectBoothManager.singleTon.selectedBooth[i];
            var _info = boothsDB.Booths[boothID];

            var fromStr = visitStartTime.ToString("H:mm");

          

            var toStr = visitStartTime.AddMinutes(15).ToString("H:mm");
            AllCards[i].SetInfo(_info.logo, _info.name, _info.Location, fromStr + "~" + toStr , boothID);

            MyReservation.myReservationInfos.Add(new MyReservationInfo() { ID = boothID, Time = fromStr + "~" + toStr });

            double timeAdd = UnityEngine.Random.Range(1, 100) > 50 ? 30 : 45;
            visitStartTime = visitStartTime.AddMinutes(timeAdd);
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
