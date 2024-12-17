using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Minigame_Advoshooto : MonoBehaviour
{
    //minigame with zombie avocado's 

    //you must shoot before they come over the line you can shoot by clicking on them with LMB

    //if they come over the line you're game over and you lose 100 avocado's
    //if you win you get 500 avocado's

    //5 zombie_avocado's/sec they reach the finish line in 3 seconds
    //total zombie_avocado's: 75 (gametime: 15 seconds)

    public GameObject zombiecado_prefab;
    public Transform spawnpoint; //position

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(zombiecado_prefab,spawnpoint); //instantiate takes GameObject, position

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
