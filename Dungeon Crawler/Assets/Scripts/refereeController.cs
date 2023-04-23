using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class refereeController : MonoBehaviour
{
    public GameObject monsterGO; //View
    public GameObject playerGO;
    private Monster theMonster;
    public TextMeshProUGUI monsterSB;
    public TextMeshProUGUI playerSB;
    private DeathMatch theMatch;
    public AudioSource jukebox;

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("goblin"); //controller
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterData.p.getData();
        this.theMatch = new DeathMatch(MasterData.p, theMonster, playerGO, monsterGO, playerSB, monsterSB, jukebox);
       // theMatch.fight();
        StartCoroutine(theMatch.fight());

    }

    // Update is called once per frame
    void Update()
    {
       // print(this.theMonster.getData());
    }
 
 
}
