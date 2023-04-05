    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //What we want to apply forces TO
    public GameObject northExit, southExit, eastExit, westExit; //Exposing exits
    public float movementSpeed = 40.0f; //Can tune in Unity editor b/c public
    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>(); //Ask Player for HIS rigidbody object, save into rb
        MasterData.setupDone.Equals(false);
     
        if(MasterData.whereDidIComeFrom.Equals("north"))
        {
            print("Force added");
            this.rb.transform.position = this.southExit.transform.position;
            //this.rb.AddForce(this.northExit.transform.position * movementSpeed);
            this.rb.AddForce(new Vector3(0.00f,0.50f,3.00f) * movementSpeed);

        }
        //print(MasterData.isMoving);
        //print(MasterData.setupDone);
        
    }

    // Update is called once per frame
    void Update()
    {
     //  print(rb.velocity);
            
            //this.rb.transform.position = (new Vector3(0,0,0));

 
        if(Input.GetKeyDown(KeyCode.UpArrow) && !MasterData.isMoving) //same as this.isMoving == false
        {
            this.rb.AddForce(this.northExit.transform.position * movementSpeed); //direction = POSITION of north exit position vector3
            MasterData.isMoving = true;
            
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow) && !MasterData.isMoving) 
        {
            this.rb.AddForce(this.westExit.transform.position * movementSpeed); 
            MasterData.isMoving = true;

        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && !MasterData.isMoving) 
        {
            this.rb.AddForce(this.eastExit.transform.position * movementSpeed); 
            MasterData.isMoving = true;

        }  
       if(Input.GetKeyDown(KeyCode.DownArrow) && !MasterData.isMoving) 
        {
            this.rb.AddForce(this.southExit.transform.position * movementSpeed); 
            MasterData.isMoving = true;
        }     
    }
    
   private void OnTriggerEnter(Collider other) 
    {
        print("Something hit me!");
        if(other.tag.Equals("Center"))
        {
            print("Player has hit center");
            //rb.velocity = Vector3.zero;
           // rb.maxAngularVelocity = 0f;
            //this.rb.drag = 0;
            //thePlayer.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity); 
            //rb.velocity = Vector3.zero;
            //thePlayer.transform.rotation = Quaternion.identity;;
            print("Right after setting to 0: " + rb.velocity);
            //print("Right after setting to 0: " + thePlayer.transform.rotation);
            MasterData.setupDone = true;
            MasterData.isMoving = false;
            this.rb.AddForce(new Vector3(0.00f,0.50f, -3.00f) * movementSpeed);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        print("I hit something!!!");
 
        if(other.gameObject.CompareTag("Exit") && MasterData.setupDone.Equals(true))  //other.gameObject.tag.Equals("Exit")
                    {
                            if(other.gameObject == this.northExit)
                            {
                                MasterData.whereDidIComeFrom = "north";
                                SceneManager.LoadScene("DungeonRoom"); //Ask scene manager to load a scene named "DugeonRoom 
                            }
                            if(other.gameObject == this.southExit)
                            {
                                MasterData.whereDidIComeFrom = "south";
                            }
                            if(other.gameObject == this.eastExit)
                            {
                                MasterData.whereDidIComeFrom = "east";
                            }
                            if(other.gameObject == this.westExit)
                            {
                                MasterData.whereDidIComeFrom = "west";
                            }
                        print(MasterData.whereDidIComeFrom);
                        MasterData.count++;
                        

                    }
    

    }
}
