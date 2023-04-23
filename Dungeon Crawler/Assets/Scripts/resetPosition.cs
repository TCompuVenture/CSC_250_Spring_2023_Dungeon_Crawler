using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPosition : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Monster")) //If I hit a Monster, I must be a player. Put me back where the Player goes!
        {

            this.GetComponent<Rigidbody>().transform.position = new Vector3(-5.4f, .0699f, 1.24f);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().Sleep();
            //this.rb.angularVelocity = Vector3.zero;
        }
        else if(other.gameObject.CompareTag("Player")) //If I hit a Player, I must be a monster. Put me back where the Monster goes!
        {
            this.GetComponent<Rigidbody>().transform.position = new Vector3(-11.45f, 0.26f, 1.28f);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().Sleep();
        }

    }
}
