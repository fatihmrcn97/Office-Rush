using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Bill_", menuName = "Scriptable Objects/Bill")]
public class BillSO : ScriptableObject
{
    public Sprite billImage;
    public string billName;
    public string billContent;
    public int billAmount;
    
}
