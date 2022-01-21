using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectBoothManager : MonoBehaviour
{

    public BoothsDB boothsDB;
    public static SelectBoothManager singleTon { get; private set; }

    public List<int> selectedBooth = new List<int>();

    public Button NextButton;
    public TMP_Text NextButtonText;

    public Transform cardRoot;
    public SearchBoothCard[] AllCards;

    // Start is called before the first frame update
    void Start()
    {
        singleTon = this;
        AllCards = cardRoot.GetComponentsInChildren<SearchBoothCard>();
        for(int i=0;i< AllCards.Length; i++)
        {
            var _info = boothsDB.Booths[i];
            AllCards[i].SetInfo(_info.logo, _info.name, _info.Location, _info.Popularity,i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnselectedBoothUpdated()
    {
        NextButtonText.text = "NEXT (" + selectedBooth.Count + " Booths Added)";
        NextButton.interactable = (selectedBooth.Count > 0 && selectedBooth.Count <=8);
    }

    public void OnSearchUpdated(TMP_InputField searchField)
    {
        var _keyword = searchField.text;

        foreach(var c in AllCards)
        {
            if (c.bothNameStr.Contains(_keyword))
            {
                c.gameObject.SetActive(true);
            }
            else
            {
                c.gameObject.SetActive(false);
            }
        }
    }
}
