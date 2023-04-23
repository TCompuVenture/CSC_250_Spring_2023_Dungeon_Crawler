using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using System;

public class DeathMatch
{
    private Inhabitant dude1;
    private Inhabitant dude2;
    private GameObject dude1go;
    private GameObject dude2go;
    private TextMeshProUGUI playerSB;
    private TextMeshProUGUI monsterSB;
    private int whoseTurn;
    private Rigidbody rb;

    //private AudioSource jukebox;

    public DeathMatch(Inhabitant dude1, Inhabitant dude2, GameObject dude1go, GameObject dude2go, TextMeshProUGUI playerSB, TextMeshProUGUI monsterSB, AudioSource jukebox)
    {
        this.dude1 = dude1;
        this.dude2 = dude2;
        this.dude1go = dude1go;
        this.dude2go = dude2go;
        this.monsterSB = monsterSB;
        this.playerSB = playerSB;
        whoseTurn = 0;  
        //this.jukebox = jukebox;
       // Console.WriteLine("hi");

    }
    public IEnumerator fight() //Bringing in game object in view that will actually be moving around
    {
        while(dude1.getHP() >= 0 && dude2.getHP() >= 0)
        {

        int D20Roll = UnityEngine.Random.Range(10,21);

        if(whoseTurn == 0) //Player goes first
        {
            whoseTurn = 1;
            if(D20Roll >= dude2.getAC())
                {
                    dude2.setHP(dude1.getDamage());
                    this.dude1go.GetComponent<Rigidbody>().AddForce(Vector3.left * 150.0f);

                // Console.WriteLine("Attack succeed");
                }
        }
        else if(whoseTurn == 1) //Monster goes first
        {
            whoseTurn = 0;
            if(D20Roll >= dude1.getAC())
                {
                    dude1.setHP(dude2.getDamage());
                    this.dude2go.GetComponent<Rigidbody>().AddForce(Vector3.right * 150.0f);
                // Console.WriteLine("Attack succeed");
                }

        }
        yield return new WaitForSecondsRealtime(4); 

        this.playerSB.text = this.dude1.getData();
        this.monsterSB.text = this.dude2.getData();

        }
        if(dude1.getHP() > 0)
        {
            MasterData.winner = this.dude1;
            this.dude2go.SetActive(false);
        }
        else if(dude2.getHP() > 0)
        {
            MasterData.winner = this.dude2;
            this.dude1go.SetActive(false);

        }


        //goes back and forth having our inhabitants "try" to attack each other. 
        //- a successful attack means that a D20 is at least as high as the target's AC
        //-upon successful attack, the target's HP is reduced by the attacker's Attack
        //-An unsuccessful attack results in no change in HP
        //go back and forth like this until an inhabitant dies
        //need to create a delay so that attack takes place at a reasonable pace
        //show whose turn it is on screen
    }
}
