using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{
    public float chanceToGetIntoFight = 30f;
    public GameObject Player;
    public bool enableAllFights = true; //If FALSE, no fights will occur, even though the enableFights variable will be set on and off by the code




    private void OnTriggerEnter(Collider other)
    {
        if(MasterData.enableFights == true && !MasterData.comingFromFight && enableAllFights) //Could probably have just used enableFights, but I'm lazy :)
        {
            int chanceToFight = Random.Range(1, 100);

            if (chanceToFight <= this.chanceToGetIntoFight)
            {
                //print("Start a Fight");

                //turn off music
                Destroy(MasterData.musicLooper);
                MasterData.musicLooper = null;
                MasterData.PlayerResumePosition = this.Player.GetComponent<Rigidbody>().transform.position;//new Vector3(this.rb.transform.position.x, this.rb.transform.position.y, this.rb.transform.position.z); 
                print(MasterData.PlayerResumePosition);
                MasterData.PlayerResumeRotation = this.Player.GetComponent<Rigidbody>().transform.rotation;
                MasterData.comingFromFight = true; 
                SceneManager.LoadScene("FightScene");
            }
            else
            {
                print("No monsters found!");
            }
        }
        
    }
}
