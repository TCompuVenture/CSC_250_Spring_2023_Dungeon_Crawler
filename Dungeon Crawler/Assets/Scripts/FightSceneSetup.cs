using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightSceneSetup : MonoBehaviour
{
    public TextMeshProUGUI monsterHP, monsterAC, playerHP, playerAC, monsterAttackPower, playerAttackPower;

    // Start is called before the first frame update
    void Start()
    {
        this.monsterHP.text = monsterHP.text + Random.Range(1,20);
        this.playerHP.text = playerHP.text + Random.Range(1,20);
        this.monsterAC.text = monsterAC.text + Random.Range(10,17);
        this.playerAC.text = playerAC.text + Random.Range(10,17);
        this.playerAttackPower.text = playerAttackPower.text + Random.Range(1,5);
        this.monsterAttackPower.text = monsterAttackPower.text + Random.Range(1,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
