using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Confirmation : MonoBehaviour
{
    public BookVisit_TimeOfStay BookVisit_TimeOfStay;
    public TMP_Text TimeOfStay;

    public GroupBoothManager groupBoothManager;

    public Transform regularHeader, LessHeader;
    public BoothsDB boothsDB;
    public Transform cardRoot;

    public GroupBoothCard[] AllCards;
    private void Awake()
    {
        AllCards = cardRoot.GetComponentsInChildren<GroupBoothCard>();
    }

    void OnEnable()
    {
        TimeOfStay.text = "Time of Stay: " + BookVisit_TimeOfStay.Start.text + " ~ " + BookVisit_TimeOfStay.End.text;

        AllCards = cardRoot.GetComponentsInChildren<GroupBoothCard>();

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

        UpdateHeader();
    }

    public void UpdateHeader()
    {
        regularHeader.SetSiblingIndex(groupBoothManager.regularHeader.GetSiblingIndex());
        LessHeader.SetSiblingIndex(groupBoothManager.LessHeader.GetSiblingIndex());
    }
}
