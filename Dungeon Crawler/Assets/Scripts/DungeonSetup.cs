using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSetup : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject westMonster, eastMonster, northMonster, southMonster;

    public bool monsterController;

    /**public bool northOn;
    public bool southOn;
    public bool eastOn;
    public bool westOn;**/
    // Start is called before the first frame update
    void Start()
    {
        MasterData.setupDungeon();
        this.eastMonster.SetActive(false);
        this.northMonster.SetActive(false);
        this.southMonster.SetActive(false);
        this.westMonster.SetActive(false);



        if(!MasterData.p.getCurrentRoom().hasExit("north"))
        {
            print("This room has not a north exit");
           // MasterData.northOn = false;
            this.northExit.SetActive(false);
        }
        if(!MasterData.p.getCurrentRoom().hasExit("south"))
        {
            print("This room has not a south exit");
           // MasterData.southOn = false;
            this.southExit.SetActive(false);

        }
        if(!MasterData.p.getCurrentRoom().hasExit("west"))
        {
            print("This room has not a west exit");
           // MasterData.westOn = false;
            this.westExit.SetActive(false);
        }        
        if(!MasterData.p.getCurrentRoom().hasExit("east"))
        {
            print("This room has not an east exit");
          //  MasterData.eastOn = false;
            this.eastExit.SetActive(false);

        }

         //Put these in for loop. Use hasExit function of wanted room to decide whether or not to turn on an exit when setting up the room.



        //HW answer in here - add back in!!!!!!!!!!!!!!!!!!!!!!!!!
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
