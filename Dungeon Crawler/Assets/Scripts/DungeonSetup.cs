using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSetup : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;

    public bool northOn, southOn, eastOn, westOn;
    // Start is called before the first frame update
    void Start()
    {
        this.northExit.SetActive(northOn);
        this.southExit.SetActive(southOn);
        this.eastExit.SetActive(eastOn);
        this.westExit.SetActive(westOn);


        //HW answer in here
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
