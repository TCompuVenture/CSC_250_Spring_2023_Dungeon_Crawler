using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{
    public bool enableFights = true;
    public float chanceToGetIntoFight = 30f;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.enableFights && !MasterData.comingFromFight) //Could probably have just used enableFights, but I'm lazy :)
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
