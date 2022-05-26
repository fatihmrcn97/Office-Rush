using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPaperDesk : MonoBehaviour
{

    public List<GameObject> paperList = new List<GameObject>();
    public Transform collectPoint;


    public Transform moneyPoin;
    public List<GameObject> moneyList;

    private Transform poolPosition;

    float SavedTime = 0;
   
    private bool oneTime;

    public DeskSO myDesk;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if ((Time.time - SavedTime) > myDesk.consumePaper)
            {
                SavedTime = Time.time;
                other.gameObject.GetComponent<CollectManager>().RemovePaperFromPlayer();
                GetPaper(other.gameObject);
            }
        }

    }
    private void Start()
    {
        oneTime = true;
        poolPosition = GameObject.FindGameObjectWithTag("pool").transform;
    }


    public void RemoveLast()
    {
        if (paperList.Count > 0)
        {
            paperList[paperList.Count - 1].SetActive(false);
            paperList[paperList.Count - 1].transform.parent = poolPosition;
            paperList.RemoveAt(paperList.Count - 1);
        }
    }
    public void RemoveLastMoney()
    {
        if (moneyList.Count > 0)
        {
            moneyList[moneyList.Count - 1].SetActive(false);
            moneyList.RemoveAt(moneyList.Count - 1);
        }
    }


    private void GetPaper(GameObject other)
    {
        if (paperList.Count <= 10 && other.gameObject.GetComponent<CollectManager>().paperList.Count > 0)
        {
            GameObject temp = PoolManager.instance.SpawnFromPool("paper", collectPoint.transform);
            if (temp == null)
                GetPaper(other);
            temp.transform.localPosition = new Vector3(collectPoint.localPosition.x, ((float)paperList.Count / 25), collectPoint.localPosition.z);
            temp.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            paperList.Add(temp);
 
        }

    }


    private void GetMoney()
    {
        if (moneyList.Count <= 10)
        {
            GameObject temp = PoolManager.instance.SpawnFromPool("money", moneyPoin.transform);

            temp.transform.localPosition = new Vector3(0, ((float)moneyList.Count / 25), 0);
            temp.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            moneyList.Add(temp);

        }

    }

    private void Update()
    {
        if (paperList.Count <= 0)
            return;
        if ((Time.time - SavedTime) > myDesk.consumePaper && oneTime)
        {
            oneTime = false;
            StartCoroutine(MakeMoney());
        }
    }

    private IEnumerator MakeMoney()
    {
        RemoveLast();
        yield return new WaitForSeconds(myDesk.produceMoney);
        GetMoney();
        yield return new WaitForSeconds(myDesk.produceMoney);
        oneTime = true;
    }

}
