using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public GameObject westStart, eastStart, northStart, southStart;
    public float movementSpeed = 40.0f;
    private bool isMoving;
    public GameObject playerCostume;
    private Room currentRoom;

    //private Room currentRoom = MasterData.p.getCurrentRoom();


    // Start is called before the first frame update
    void Start()
    {
        this.currentRoom = MasterData.thePlayer.getCurrentRoom();
        print("At top of PlayerController Start: " + MasterData.PlayerResumePosition);
        print(MasterData.whereDidIComeFrom);
        this.rb = this.GetComponent<Rigidbody>();
        this.updateExits();
        this.isMoving = true;
        if(MasterData.PlayerResumePosition == new Vector3(0.0f, 0.0f, 0.0f))
        {
        print("doing setup");
        if (!MasterData.whereDidIComeFrom.Equals("?"))
        {
            if(MasterData.whereDidIComeFrom.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.playerCostume.transform.LookAt(this.northExit.transform);
                this.rb.AddForce(Vector3.forward * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.playerCostume.transform.LookAt(this.southExit.transform);

                this.rb.AddForce(Vector3.back * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.playerCostume.transform.LookAt(this.westExit.transform);

                this.rb.AddForce(Vector3.left * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.playerCostume.transform.LookAt(this.eastExit.transform);
                this.rb.AddForce(Vector3.right * 150.0f);
            }
        }
        }
        else if(MasterData.PlayerResumePosition != new Vector3(0.0f, 0.0f, 0.0f))
        {
            this.rb.transform.position = MasterData.PlayerResumePosition;
            print(MasterData.whereDidIComeFrom);
            MasterData.shouldFollowRotation = false;
           // this.rb.transform.rotation = MasterData.PlayerResumeRotation;
            if (MasterData.playerDirectionOfTravel.Equals("?")) //If I don't know where I came from, (?) just set me facing North and give me a shove!
            {
                this.playerCostume.transform.LookAt(this.northExit.transform);
                this.rb.AddForce(Vector3.forward * 150.0f);
            }
            if(MasterData.playerDirectionOfTravel.Equals("north")) 
            {
                this.playerCostume.transform.LookAt(this.northExit.transform);
                this.rb.AddForce(Vector3.forward * 150.0f);
            }
            else if (MasterData.playerDirectionOfTravel.Equals("south"))
            {
                this.playerCostume.transform.LookAt(this.southExit.transform);
                this.rb.AddForce(Vector3.back * 150.0f);
            }
            else if (MasterData.playerDirectionOfTravel.Equals("west"))
            {
                this.playerCostume.transform.LookAt(this.westExit.transform);
                this.rb.AddForce(Vector3.left * 150.0f);
            }
            else if (MasterData.playerDirectionOfTravel.Equals("east"))
            {
                this.playerCostume.transform.LookAt(this.eastExit.transform);
                this.rb.AddForce(Vector3.right * 150.0f);
            }
            MasterData.PlayerResumePosition = new Vector3(0.0f, 0.0f, 0.0f);
            MasterData.isExiting = true;
        }
        StartCoroutine(PlayerHeal());

     
    }

    private void updateExits()
    {
       // Room currentRoom = MasterData.p.getCurrentRoom();

        if(currentRoom.hasExit("north") == false)
        {
            this.northExit.SetActive(false);
        }
        if (currentRoom.hasExit("south") == false)
        {
            this.southExit.SetActive(false);
        }
        if (currentRoom.hasExit("east") == false)
        {
            this.eastExit.SetActive(false);
        }
        if (currentRoom.hasExit("west") == false)
        {
            this.westExit.SetActive(false);
        }
    }

    IEnumerator PlayerHeal()
    {
        yield return new WaitForSeconds(3f);
        MasterData.thePlayer.healHP(1);
        StartCoroutine(PlayerHeal()); //Indirect recursion

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("center"))
        {
            this.rb.velocity = Vector3.zero;
            this.rb.Sleep();
            MasterData.comingFromFight = false;
            this.isMoving = false;
            MasterData.enableFights = true;
            //this.rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Exit") && MasterData.isExiting)
        {
            MasterData.enableFights = false;

            if(other.gameObject == this.northExit)
            {
                currentRoom.takeExit(MasterData.thePlayer, "north");
                MasterData.whereDidIComeFrom = "north";
            }
            else if (other.gameObject == this.southExit)
            {
                MasterData.whereDidIComeFrom = "south";
                currentRoom.takeExit(MasterData.thePlayer, "south");

            }
            else if (other.gameObject == this.eastExit)
            {
                currentRoom.takeExit(MasterData.thePlayer, "east");
                MasterData.whereDidIComeFrom = "east";
            }
            else if (other.gameObject == this.westExit)
            {
                MasterData.whereDidIComeFrom = "west";
                currentRoom.takeExit(MasterData.thePlayer, "west");

            }
            MasterData.isExiting = false;
            SceneManager.LoadScene("DungeonRoom");
        }
        else if(other.gameObject.CompareTag("Exit") && !MasterData.isExiting)
        {
            MasterData.isExiting = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Room currentRoom = MasterData.thePlayer.getCurrentRoom();


        if (Input.GetKeyDown(KeyCode.UpArrow) && this.isMoving == false)
        {
            if(currentRoom.hasExit("north"))
            {
                this.playerCostume.transform.LookAt(this.northExit.transform);
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                this.isMoving = true;
                MasterData.playerDirectionOfTravel = "north";
               // currentRoom.takeExit(MasterData.p, "north");

            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("west"))
            {
                this.playerCostume.transform.LookAt(this.westExit.transform);
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                this.isMoving = true;
                MasterData.playerDirectionOfTravel = "west";
               // currentRoom.takeExit(MasterData.p, "west");

            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("east"))
            {
                this.playerCostume.transform.LookAt(this.eastExit.transform);
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                this.isMoving = true;
                MasterData.playerDirectionOfTravel = "east";
              //  currentRoom.takeExit(MasterData.p, "east");

            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && this.isMoving == false)
        {
            if (currentRoom.hasExit("south"))
            {
                this.playerCostume.transform.LookAt(this.southExit.transform);
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                MasterData.playerDirectionOfTravel = "south";
                this.isMoving = true;
               // currentRoom.takeExit(MasterData.p, "south");

            }
        }

    }
}
