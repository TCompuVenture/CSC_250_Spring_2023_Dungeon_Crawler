using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //What we want to apply forces TO
    private bool isMoving;
    public GameObject northExit, southExit, eastExit, westExit; //Exposing exits
    public float movementSpeed = 40.0f; //Can tune in Unity editor b/c public
    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>(); //Ask Player for HIS rigidbody object, save into rb
        print(MasterData.count); 
        this.isMoving = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && !isMoving) //same as this.isMoving == false
        {
            this.rb.AddForce(this.northExit.transform.position * movementSpeed); //direction = POSITION of north exit position vector3
           // movementSpeed = 0;
            this.isMoving = true;
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving) 
        {
            this.rb.AddForce(this.westExit.transform.position * movementSpeed); 
           // movementSpeed = 0;
            this.isMoving = true;

        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && !isMoving) 
        {
            this.rb.AddForce(this.eastExit.transform.position * movementSpeed); 
           // movementSpeed = 0;
            this.isMoving = true;

        }  
       if(Input.GetKeyDown(KeyCode.DownArrow) && !isMoving) 
        {
            this.rb.AddForce(this.southExit.transform.position * movementSpeed); 
           // movementSpeed = 0;
            this.isMoving = true;
        }     
    }
    private void OnTriggerExit(Collider other)
    {
            if(other.gameObject.CompareTag("Exit"))  //other.gameObject.tag.Equals("Exit")
            {
                    if(other.gameObject == this.northExit)
                    {
                        MasterData.whereDidIComeFrom = "north";
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
                MasterData.whereDidIComeFrom = "north";
                SceneManager.LoadScene("DungeonRoom"); //Ask scene manager to load a scene named "DugeonRoom"

            }
    }
}
