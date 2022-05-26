using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PayBill : MonoBehaviour
{
    [SerializeField] private BillSO myBill;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI classTxt;
    [SerializeField] private TextMeshProUGUI attributes;
    [SerializeField] private TextMeshProUGUI moneyTxt;
    [SerializeField] private Text BtnTxt;


    private void Start()
    {
        image.sprite = myBill.billImage;
        classTxt.text = myBill.billName;
        attributes.text = myBill.billContent;
        moneyTxt.text = myBill.billAmount.ToString();
    }

    
    public void Pay_Bill_Electricity()
    {
        Debug.Log("bill paid electircy");
        // gold spend
        if (PlayerCoin.instance.player_coin > myBill.billAmount)
        {
        PlayerCoin.instance.RemoveCoin(myBill.billAmount);
            // print continou

        }
        else
        {
            // nothing happen
        }

    }
    public void Pay_Bill_Worker()
    {
        Debug.Log("bill paid worker");
        // gold spend
        if (PlayerCoin.instance.player_coin > myBill.billAmount)
        {
            PlayerCoin.instance.RemoveCoin(myBill.billAmount);
            // print continou

        }
        else
        {
            // nothing happen
        }

    }
}
