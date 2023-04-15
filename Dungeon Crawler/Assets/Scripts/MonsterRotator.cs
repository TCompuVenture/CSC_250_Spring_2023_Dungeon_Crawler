using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRotator : MonoBehaviour
{
    private Vector3 rotationVector = new Vector3(15,30,45);

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotationVector * Time.deltaTime); //delaTime = time that has passed since last call to update. INDEPENDENT of framerate
    }
}