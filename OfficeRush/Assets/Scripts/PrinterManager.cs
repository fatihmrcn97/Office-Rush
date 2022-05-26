using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform exitPoint;
    bool isWorking = true;
    int stackCount = 10;
    public static bool isPaperThere = true;

    public static bool isBillPaidElectricty=true;

    private Transform poolPosition;
    private IEnumerator Start()
    {
        isBillPaidElectricty = true;
        yield return new WaitForSeconds(1);
        StartCoroutine(PrintPaper());
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

    IEnumerator PrintPaper()
    {
        while (true)
        {
            float papaerCount = paperList.Count;
            int rowCount = paperList.Count / stackCount;
            if (isWorking)
            {
                GameObject temp = PoolManager.instance.SpawnFromPool("paper", transform);
                if(temp==null)
                    temp = PoolManager.instance.SpawnFromPool("paper", transform); 
                temp.transform.position = new Vector3(exitPoint.position.x, (papaerCount % stackCount) / 21, exitPoint.position.z + ((float)rowCount / 2.4f));

                if (temp.activeInHierarchy)
                    paperList.Add(temp);
            }
            if (paperList.Count >= 30)
            {
                isWorking = false;

            }
            else
            {
                isWorking = true;
            }

            if (isBillPaidElectricty)
            {
              //  isWorking = false;
            }
            else
            {
               // isWorking = true;
            }


            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {

        if (paperList.Count < 1)
            isPaperThere = false;
        else
            isPaperThere = true;
    }

}
