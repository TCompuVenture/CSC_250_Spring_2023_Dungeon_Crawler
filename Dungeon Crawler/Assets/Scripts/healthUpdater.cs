using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class healthUpdater : MonoBehaviour
{
    public GameObject[] barPartArray;
    private int numToEnable;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(updateHealth());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator updateHealth()
    {
        yield return null;
        numToEnable = (MasterData.thePlayer.getHP()) * 10 / MasterData.thePlayer.getMaxHP(); //CHANGE TO NUM TO DISABLE?!
        print(numToEnable);

        for(int i = 9; i >= numToEnable; i--)
        {
            barPartArray[i].SetActive(false);
        }
        for(int i = 0; i < numToEnable; i++)
        {
            barPartArray[i].SetActive(true);
        }
        StartCoroutine(updateHealth());
        yield return new WaitForSeconds(1.0f);
    }
}
