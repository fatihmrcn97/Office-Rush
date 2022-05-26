using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayBillTrigger : MonoBehaviour
{
    public GameObject payBillUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            payBillUI.SetActive(true); 
    }   private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            payBillUI.SetActive(false); 
    }
}
