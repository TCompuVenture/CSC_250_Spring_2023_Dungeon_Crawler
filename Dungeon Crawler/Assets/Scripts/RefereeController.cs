using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RefereeController : MonoBehaviour
{
    public GameObject monsterGO;
    public GameObject playerGO;
    public TextMeshProUGUI monsterSB;
    public TextMeshProUGUI playerSB;
    private Monster theMonster;
    private DeathMatch theMatch;
    public GameObject fightJukeBox;
    public GameObject winnerJukeBox;
    public GameObject loserJukeBox;

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("goblin");
        this.updateScore();
        this.theMatch = new DeathMatch(MasterData.p, this.theMonster, this.playerGO, this.monsterGO, this);
        StartCoroutine(DelayBeforeFight());   
    }

    public void playEndOfFightMusic(string whichMusic)
    {
        this.fightJukeBox.SetActive(false);
        if(whichMusic.Equals("playerWin"))
        {
            this.winnerJukeBox.SetActive(true);
        }
        else if(whichMusic.Equals("monsterWin"))
        {
            this.loserJukeBox.SetActive(true);
        }
    }
    public void updateScore()
    {
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterData.p.getData();
    }

    IEnumerator DelayBeforeFight()
    {
        yield return new WaitForSeconds(0.5f);
        this.theMatch.fight();
        
    }

    

// Update is called once per frame
    void Update()
    {
        
    }
}
