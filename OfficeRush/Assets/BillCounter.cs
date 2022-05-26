using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BillCounter : MonoBehaviour
{

    public static BillCounter instance;

    public int debtAmount;
    float SavedTime = 0;
    float DelayTime = 20f;

    public TextMeshProUGUI debtText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        debtAmount = 0;

    }

    private void FixedUpdate()
    {
        
            if ((Time.time - SavedTime) > DelayTime)
            {
            SavedTime = Time.time;
            debtAmount -= 1;
            debtTextRefresh();
            }
    }

    public void debtTextRefresh()
    {
        debtText.text = debtAmount.ToString();
    }
}
