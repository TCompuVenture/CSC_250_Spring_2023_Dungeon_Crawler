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
        print(MasterData.count); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) //If uparrow became pressed down during frame, DO something
        {
            this.rb.AddForce(this.northExit.transform.position * movementSpeed); //direction = POSITION of north exit position vector3
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)) //ignore for right now - load next room, but with only appropriate exits enabled. We will have a scene that represents every room.
        {
            MasterData.count++;
            SceneManager.LoadScene("DungeonRoom"); //Ask scene manager to load a scene named "DugeonRoom"
        }
    }
}
