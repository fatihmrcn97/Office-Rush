using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShopUIHandle : MonoBehaviour
{
    [SerializeField] private DeskSO myDesk;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI classTxt;
    [SerializeField] private TextMeshProUGUI attributes;
    [SerializeField] private TextMeshProUGUI moneyTxt;
    [SerializeField] private Text BtnTxt;

    [SerializeField] private Transform deskPos;
    public GameObject buyChairObject;

    public GameObject notEnoughMoneyTxt;
    private void OnEnable()
    {
        image.sprite = myDesk.iconImage;
        classTxt.text = myDesk.class_of_desk;
        attributes.text = "Consume" + myDesk.consumePaper.ToString() + "Produce" + myDesk.produceMoney.ToString();
        moneyTxt.text = myDesk.buyPrice.ToString();

    }


   
}
