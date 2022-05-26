using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerCoin : MonoBehaviour
{
    public static PlayerCoin instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [HideInInspector]public int player_coin;
    public TextMeshProUGUI coinCountText;

    private void Start()
    {
        player_coin = PlayerPrefs.GetInt("playerCoin");
        TextHandle();
    }


    public void AddCoin(int coinNum)
    {
        player_coin += coinNum;
        TextHandle();
    }

    private void TextHandle()
    {
        coinCountText.text = player_coin.ToString();
    }

    public void RemoveCoin(int coinNum)
    {
        player_coin -= coinNum;
        TextHandle();
    }
}
