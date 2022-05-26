using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Desk_",menuName ="Scriptable Objects/Desk")]
public class DeskSO : ScriptableObject
{
    public GameObject prefabOfDesk;
    public Sprite iconImage;
    public string class_of_desk;
    public int buyPrice;
    public float consumePaper;
    public float produceMoney;
     
}
