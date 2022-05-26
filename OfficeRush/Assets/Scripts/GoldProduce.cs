using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldProduce : MonoBehaviour
{
    float SavedTime = 0;
    float DelayTime = .2f;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if ((Time.time - SavedTime) > DelayTime && other.gameObject.GetComponent<MoneyCollect>().moneyList.Count > 0)
            {
                SavedTime = Time.time;
                other.gameObject.GetComponent<MoneyCollect>().RemoveLast();


                // Produce Coin
                other.gameObject.GetComponent<PlayerCoin>().AddCoin(1);
            }
        }
    }

}
