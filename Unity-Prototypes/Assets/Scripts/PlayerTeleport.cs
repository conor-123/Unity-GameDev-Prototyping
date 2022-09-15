using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//TO-DO NOT WORKING

public class PlayerTeleport : MonoBehaviour
{

    PlayerMovement PlayerMovement;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = gameObject.GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //check for import to trigger teleport
        if(Input.GetButtonDown("Jump")) {
            Debug.Log("Test");
            gameObject.transform.position = new Vector3(25f, 0f, 0f);
        }
        
    }
}
