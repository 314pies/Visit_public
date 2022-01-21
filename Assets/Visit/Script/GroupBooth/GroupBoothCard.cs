using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GroupBoothCard : MonoBehaviour
{
    

    public Image logo;
    public TMP_Text BoothName, Locatio, Popularity;

    public int boothID;

    public void SetInfo(Sprite logo, string boothName, string Location, int popularity, int ID)
    {
        this.logo.sprite = logo;
        BoothName.text = boothName;
        Locatio.text = "" + Location;
        Popularity.text = popularity + "%";
        boothID = ID;

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
