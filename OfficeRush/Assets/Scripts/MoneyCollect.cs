using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollect : MonoBehaviour
{

    public Transform moneyPoin;
    public List<GameObject> moneyList;

    float SavedTime = 0;
    float DelayTime = .2f;
    private bool oneTime;

    Transform poolPosition;
    private void Start()
    {
        poolPosition = GameObject.FindGameObjectWithTag("pool").transform;
    }

    public void RemoveLast()
    {
        if (moneyList.Count > 0)
        {
            moneyList[moneyList.Count - 1].SetActive(false);
            moneyList[moneyList.Count - 1].transform.parent = poolPosition;
            moneyList.RemoveAt(moneyList.Count - 1);
        }
    }


    private void GetMoney(GameObject other)
    {
        if (moneyList.Count <= 10 && other.gameObject.GetComponentInParent<CollectPaperDesk>().moneyList.Count>0 && GetComponent<CollectManager>().paperList.Count == 0)
        {
            GameObject temp = PoolManager.instance.SpawnFromPool("money", moneyPoin.transform);
            temp.transform.localPosition = new Vector3(0, ((float)moneyList.Count / 25), 0);
            temp.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            moneyList.Add(temp);

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("desk"))
        {
            if ((Time.time - SavedTime) > DelayTime)
            {
                GetMoney(other.gameObject);
                other.gameObject.GetComponentInParent<CollectPaperDesk>().RemoveLastMoney();
            }
        }
    }
}
