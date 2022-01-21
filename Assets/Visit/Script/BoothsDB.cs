using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Booths", menuName = "ScriptableObjects/BoothsDB", order = 1)]
public class BoothsDB : ScriptableObject
{
    public Sprite[] BoothsRaw;
    public BoothInfo[] Booths;
    string st = "ABCDEFGHIJKLMNPQRSTUVWXYZ";



    [Button]
    public void GenerateBoothDB()
    {
        List<BoothInfo> boothsInfo = new List<BoothInfo>();
        foreach (var b in BoothsRaw)
        {
            var _newBoothInfo = new BoothInfo();
            _newBoothInfo.name = b.name;
            _newBoothInfo.logo = b;
            char c = st[Random.Range(0, st.Length)];
            _newBoothInfo.Location = "" + Random.Range(1, 7) + c + "#" + Random.Range(1,50);
            _newBoothInfo.Popularity = Random.Range(60,100);
            boothsInfo.Add(_newBoothInfo);
        }
        Booths = boothsInfo.ToArray();
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }

    [System.Serializable]
    public class BoothInfo
    {
        public string name;
        public Sprite logo;
        public string Location;
        public int Popularity;
    }
}