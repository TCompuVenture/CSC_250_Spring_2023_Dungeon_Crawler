using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMatch
{
    private Inhabitant dude1;
    private Inhabitant dude2;
    private GameObject dude1GO;
    private GameObject dude2GO;
    private Rigidbody currRigidBodyOfAttacker;
    private Rigidbody currRigidBodyOfTarget;
    private float attackMoveDistance = 2.5f;
    private Vector3 attackerOriginalPosition;
    private Inhabitant currentAttacker;
    private GameObject currentAttackerGO;
    private Inhabitant currentTarget;
    private GameObject currentTargetGO;
    private MonoBehaviour refereeInstance;
    private GameObject playerCostume;
    private GameObject monsterCostume;
    private AudioClip victoryMusic;

    public DeathMatch(Inhabitant dude1, Inhabitant dude2, GameObject dude1GO, GameObject dude2GO, MonoBehaviour refereeInstance, GameObject playerCostume, GameObject monsterCostume, AudioClip victoryMusic)
    {
        this.dude1 = dude1;
        this.dude2 = dude2;
        this.dude1GO = dude1GO;
        this.dude2GO = dude2GO;
        this.currentAttacker = this.dude1;
        this.currentAttackerGO = this.dude1GO;
        this.currentTarget = this.dude2;
        this.currentTargetGO = this.dude2GO;
        this.refereeInstance = refereeInstance;
        this.playerCostume = playerCostume;
        this.monsterCostume = monsterCostume;
        this.victoryMusic = victoryMusic;
    }

    //this is basically a thread (like our worker bees from Java)
    IEnumerator MoveObjectRoutine()
    {
        //yield return new WaitForSeconds(1.5f);
        Vector3 originalPosition = this.attackerOriginalPosition;
        Vector3 targetPosition = originalPosition + this.currentAttackerGO.transform.right * attackMoveDistance;

        this.currRigidBodyOfAttacker.MovePosition(targetPosition);

        yield return new WaitForSeconds(1.0f);

        this.currRigidBodyOfAttacker.MovePosition(originalPosition);

        //try to hit target here
        if(Dice.roll(20) >= this.currentTarget.getAC())
        {
            this.currentTarget.takeDamage(this.currentAttacker.getDamage());
        }

        

        yield return new WaitForSeconds(.5f);

        //this.refereeInstance.BroadcastMessage("updateScore");
        ((RefereeController)this.refereeInstance).updateScore(currentAttackerGO.tag);

        yield return new WaitForSeconds(.5f); //makes scoreboard line up with what's actually happening on screen


        if(this.currentTarget.isDead())
        {
            //((RefereeController)this.refereeInstance).updateScore(currentAttackerGO.tag); //extra - for debug

            MasterData.musicLooper.GetComponent<AudioSource>().Stop();           
            MasterData.musicLooper.GetComponent<AudioSource>().clip = victoryMusic;
            MasterData.musicLooper.GetComponent<AudioSource>().Play();

            if(currentTargetGO.tag == "Player")
            {
                this.playerCostume.transform.Rotate(180.0f, 0.0f, 0.0f); //Flip dead guy over
                this.playerCostume.transform.position = new Vector3(this.currentTargetGO.transform.position.x,3,this.currentTargetGO.transform.position.z); //Move dead guy up so he doesn't get flipped underneath the floor!
                //this.playerCostume.transform.LookAt(new Vector3(originalPosition.x, 0, originalPosition.z));
              //  this.monsterCostume.transform.LookAt(new Vector3(originalPosition.x, -10, originalPosition.z));

            }
            else if (currentTargetGO.tag == "Monster")
            {
                this.monsterCostume.transform.Rotate(180.0f, 0.0f, 0.0f); //Flip dead guy over
                this.monsterCostume.transform.position = new Vector3(this.currentTargetGO.transform.position.x,3,this.currentTargetGO.transform.position.z); //Move dead guy up so he doesn't get flipped underneath the floor!
                //this.playerCostume.transform.LookAt(new Vector3(originalPosition.x, -20, originalPosition.z));
            }
            for(int i = 0; i < 10; i++)
            {
                //this.attackerOriginalPosition = this.currentAttackerGO.transform.position;
                this.currRigidBodyOfAttacker.MovePosition(new Vector3(this.currentAttackerGO.transform.position.x, this.currentAttackerGO.transform.position.y+8, this.currentAttackerGO.transform.position.z));
                yield return new WaitForSeconds(1.0f);
                this.currRigidBodyOfAttacker.MovePosition(attackerOriginalPosition);
                yield return new WaitForSeconds(1.0f);

            }

            //what happens when our fight is over?
            //1. Make the dead guy fall over
            //2. Make the winner jump up and down
            //3. Player Victory Music

        }
        else
        {
            //call the fight method again after this guy is done moving
            if (this.currentAttackerGO == this.dude1GO)
            {
                this.currentAttackerGO = this.dude2GO;
                this.currentAttacker = this.dude2;
                this.currentTarget = this.dude1;
                this.currentTargetGO = this.dude1GO;
               // this.currRigidBodyOfAttacker = this.currentTargetGO.GetComponent<currRigidBodyOfAttacker>();
            }
            else
            {
                this.currentAttackerGO = this.dude1GO;
                this.currentAttacker = this.dude1;
                this.currentTarget = this.dude2;
                this.currentTargetGO = this.dude2GO;
            }
            this.fight();
        }
    }

    public void fight()
    {
        //goes back and forth having our Inhabitant "try" to attack each other
        //- a successful attack means that a D20 is at least as high as the targets AC
        //-upon successful attack, the targets HP reduce by the attackers Attack
        //-an unsuccessful attack results in no change in HP
        //go back and forth like this until an inhabitant dies
        //while(true)
        //{
            this.attackerOriginalPosition = this.currentAttackerGO.transform.position;
            this.currRigidBodyOfAttacker = this.currentAttackerGO.GetComponent<Rigidbody>();
            this.currRigidBodyOfTarget = this.currentTargetGO.GetComponent<Rigidbody>();            
            this.attackMoveDistance *= -1;


            ((RefereeController)this.refereeInstance).updateScore(currentAttackerGO.tag);
            this.refereeInstance.StartCoroutine(MoveObjectRoutine());

        //}
        
    }
}
