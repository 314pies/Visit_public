using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchBoothCard : MonoBehaviour
{


    public TMP_Text boothName;
    public string bothNameStr { get { return boothName.text; } }

    public Image logo;
    public TMP_Text BoothName, Locatio, Popularity;

    public int ID;

    public void SetInfo(Sprite logo, string boothName, string Location, int popularity, int ID)
    {
        this.logo.sprite = logo;
        BoothName.text = boothName;
        Locatio.text = "Location: " + Location;
        Popularity.text = "Popularity: " + popularity + "%";
        this.ID = ID;
        UpdatePopularImgColor(popularity);
    }

    bool isSelected = false;

    public GameObject selectedIndicater;

    public Color SelectedColor;

    public void OnBeClicked()
    {
        isSelected = !isSelected;
        selectedIndicater.SetActive(isSelected);
        Debug.Log("");
        if (isSelected)
        {
            SelectBoothManager.singleTon.selectedBooth.Add(this.ID);
            GetComponent<Image>().color = SelectedColor;
        }
        else
        {
            SelectBoothManager.singleTon.selectedBooth.Remove(this.ID);
            GetComponent<Image>().color = Color.white;
        }
        SelectBoothManager.singleTon.OnselectedBoothUpdated();
    }

    public Color NormalColor;
    public Color PopularColor;
    public Image popularImg;
    public void UpdatePopularImgColor(int popularity)
    {
        Color color = new Color();

        float _popCol = ((float)(popularity - 60)) / 40;

        color.r = Mathf.Lerp(NormalColor.r, PopularColor.r, _popCol);
        color.g = Mathf.Lerp(NormalColor.g, PopularColor.b, _popCol);
        color.b = Mathf.Lerp(NormalColor.g, PopularColor.b, _popCol);
        color.a = 1;

        popularImg.color = color;
    }
}
