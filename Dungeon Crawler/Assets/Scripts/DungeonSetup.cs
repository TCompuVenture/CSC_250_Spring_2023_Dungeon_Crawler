using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSetup : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;

    public bool northOn;
    public bool southOn;
    public bool eastOn;
    public bool westOn;
    // Start is called before the first frame update
    void Start()
    {
        MasterData.setupDungeon();
        this.northOn = false;
        this.southOn = false;
        this.eastOn = false;
        this.westOn = false;

        this.northExit.SetActive(northOn);
        this.southExit.SetActive(southOn);
        this.westExit.SetActive(westOn);
        this.eastExit.SetActive(eastOn);

        if(MasterData.p.getCurrentRoom().hasExit("north"))
        {
            print("This room has a north exit");
            this.northOn = true;
            this.northExit.SetActive(northOn);
        }
        if(MasterData.p.getCurrentRoom().hasExit("south"))
        {
            print("This room has a south exit");
            this.southOn = true;
            this.southExit.SetActive(southOn);
        }
        if(MasterData.p.getCurrentRoom().hasExit("west"))
        {
            print("This room has a west exit");
            this.westOn = true;
            this.westExit.SetActive(westOn);
        }        
        if(MasterData.p.getCurrentRoom().hasExit("east"))
        {
            print("This room has an east exit");
            this.eastOn = true;
            this.eastExit.SetActive(eastOn);
        }

         //Put these in for loop. Use hasExit function of wanted room to decide whether or not to turn on an exit when setting up the room.



        //HW answer in here - add back in!!!!!!!!!!!!!!!!!!!!!!!!!
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
