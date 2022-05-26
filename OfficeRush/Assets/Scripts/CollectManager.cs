using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    public Transform collectPoint;

    
    private Transform poolPosition;
    private void Start()
    {
        poolPosition = GameObject.FindGameObjectWithTag("pool").transform;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            if (paperList.Count < 10)
            {
            GetPaper();
            other.gameObject.GetComponent<PrinterManager>().RemoveLast();
            }
        }
    }

    private void GetPaper()
    {
        if(paperList.Count <= 10 && PrinterManager.isPaperThere && GetComponent<MoneyCollect>().moneyList.Count==0)
        {
            GameObject temp = PoolManager.instance.SpawnFromPool("paper",collectPoint.transform);
            if (temp == null)
                GetPaper();
            temp.transform.localPosition = new Vector3(collectPoint.localPosition.x, ((float)paperList.Count / 25), collectPoint.localPosition.z);
            temp.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
            paperList.Add(temp);
           
        }
       
    }

    public void RemovePaperFromPlayer()
    {
        if (paperList.Count > 0)
        {
            paperList[paperList.Count - 1].SetActive(false);
            paperList[paperList.Count - 1].transform.parent = poolPosition;
            paperList.RemoveAt(paperList.Count - 1);
        }
    }

}
