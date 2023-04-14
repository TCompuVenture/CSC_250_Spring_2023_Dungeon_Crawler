using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSetup : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;

    /**public bool northOn;
    public bool southOn;
    public bool eastOn;
    public bool westOn;**/
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            print(Random.Range(1,10));

        }
        MasterData.setupDungeon();
        MasterData.northOn = false;
        MasterData.southOn = false;
        MasterData.eastOn = false;
        MasterData.westOn = false;

        this.northExit.SetActive(MasterData.northOn);
        this.southExit.SetActive(MasterData.southOn);
        this.westExit.SetActive(MasterData.westOn);
        this.eastExit.SetActive(MasterData.eastOn);

        if(MasterData.p.getCurrentRoom().hasExit("north"))
        {
            print("This room has a north exit");
            MasterData.northOn = true;
            this.northExit.SetActive(MasterData.northOn);
        }
        if(MasterData.p.getCurrentRoom().hasExit("south"))
        {
            print("This room has a south exit");
            MasterData.southOn = true;
            this.southExit.SetActive(MasterData.southOn);
        }
        if(MasterData.p.getCurrentRoom().hasExit("west"))
        {
            print("This room has a west exit");
            MasterData.westOn = true;
            this.westExit.SetActive(MasterData.westOn);
        }        
        if(MasterData.p.getCurrentRoom().hasExit("east"))
        {
            print("This room has an east exit");
            MasterData.eastOn = true;
            this.eastExit.SetActive(MasterData.eastOn);
        }

         //Put these in for loop. Use hasExit function of wanted room to decide whether or not to turn on an exit when setting up the room.



        //HW answer in here - add back in!!!!!!!!!!!!!!!!!!!!!!!!!
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
