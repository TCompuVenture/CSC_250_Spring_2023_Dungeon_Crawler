using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //What we want to apply forces TO
    private bool test = false;
    public GameObject northExit, southExit, eastExit, westExit; //Exposing exits
    public float movementSpeed = 40.0f; //Can tune in Unity editor b/c public
    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>(); //Ask Player for HIS rigidbody object, save into rb
        print(MasterData.count); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && test.Equals(false)) //If uparrow became pressed down during frame, DO something
        {
            this.rb.AddForce(this.northExit.transform.position * movementSpeed); //direction = POSITION of north exit position vector3
            movementSpeed = 0;
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            this.rb.AddForce(this.westExit.transform.position * movementSpeed); 
            movementSpeed = 0;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            this.rb.AddForce(this.eastExit.transform.position * movementSpeed); 
            movementSpeed = 0;
        }  
       if(Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            this.rb.AddForce(this.southExit.transform.position * movementSpeed); 
            movementSpeed = 0;
        }     
    }
    private void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.CompareTag("Exit"))  //other.tag.Equals("pickup")
            {
                print("found exit");
                MasterData.count++;
                SceneManager.LoadScene("DungeonRoom"); //Ask scene manager to load a scene named "DugeonRoom"

            }
    }
}
