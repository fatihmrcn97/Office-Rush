using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyChairTrigger : MonoBehaviour
{

    [SerializeField] private List<DeskSO> myDesk;
    [SerializeField] private Transform deskPos;
    public GameObject notEnoughMoneyTxt;

    public GameObject UIBuyCanvasOpen;
     

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIBuyCanvasOpen.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIBuyCanvasOpen.SetActive(false);
        }
    }

    private void OnDisable()
    {
      
    }

    public void BuyDesk(int deskNum)
    {
       
            if (PlayerCoin.instance.player_coin > myDesk[deskNum].buyPrice)
            {
                GameObject desk = Instantiate(myDesk[deskNum].prefabOfDesk);
                desk.transform.position = deskPos.position;
                UIBuyCanvasOpen.SetActive(false);
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(NotEnoughMoney());
            }
      

    }



    IEnumerator NotEnoughMoney()
    {
        // Not enough money
        notEnoughMoneyTxt.SetActive(true);
        yield return new WaitForSeconds(2);
        notEnoughMoneyTxt.SetActive(false);

    }

}
