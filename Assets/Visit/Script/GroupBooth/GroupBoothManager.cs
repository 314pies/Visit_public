using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupBoothManager : MonoBehaviour
{


    public BoothsDB boothsDB;
    public static GroupBoothManager singleTon { get; private set; }

    public Transform cardRoot;

    public GroupBoothCard[] AllCards;
    private void Awake()
    {
        AllCards = cardRoot.GetComponentsInChildren<GroupBoothCard>();
    }

    void OnEnable()
    {
        singleTon = this;
       

        for (int i = 0; i < AllCards.Length; i++)
        {
            var _info = boothsDB.Booths[i];
            AllCards[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < SelectBoothManager.singleTon.selectedBooth.Count && i < 8; i++)
        {
            AllCards[i].gameObject.SetActive(true);
            var boothID = SelectBoothManager.singleTon.selectedBooth[i];
            var _info = boothsDB.Booths[boothID];
            AllCards[i].SetInfo(_info.logo, _info.name, _info.Location, _info.Popularity, boothID);
        }

        for (int i = 0; i < AllCards.Length; i++)
        {
            if (!AllCards[i].isActiveAndEnabled)
            {
                AllCards[i].transform.SetAsLastSibling();
            }
        }

    }

    public Transform regularHeader, LessHeader;
}
