using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWaitTimePage : MonoBehaviour
{

    public BoothsDB boothsDB;



    public Transform cardRoot;
    public WaitTimeCard[] AllCards;

    // Start is called before the first frame update
    void Start()
    {
        AllCards = cardRoot.GetComponentsInChildren<WaitTimeCard>();
        for (int i = 0; i < AllCards.Length; i++)
        {
            var _info = boothsDB.Booths[i];

            string waitTime = "";

            int h = Random.Range(0, 2);
            int m = Random.Range(1, 59);

            if(h > 0) { waitTime = h + " hr "; };

            waitTime += m + " min";

            AllCards[i].SetInfo(_info.logo, _info.name, _info.Location, waitTime, i);
        }
    }
}
