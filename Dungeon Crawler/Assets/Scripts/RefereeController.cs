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
    public GameObject playerCostume;
    public GameObject monsterCostume;
    public AudioClip victoryMusic;

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("goblin");
        this.updateScore("randomDebugTextAboutNothing");
        this.theMatch = new DeathMatch(MasterData.p, this.theMonster, this.playerGO, this.monsterGO, this, playerCostume, monsterCostume, this.victoryMusic);
        StartCoroutine(DelayBeforeFight());   
    }

    public void updateScore(string debugText)
    {
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterData.p.getData();
        //this.playerSB.text = debugText;
    }

    IEnumerator DelayBeforeFight()
    {
        yield return new WaitForSeconds(0.5f);
        this.theMatch.fight();
       // print("Test");
        
    }

    

// Update is called once per frame
    void Update()
    {
        
    }
}
