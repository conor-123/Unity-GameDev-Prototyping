using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=2IhzPTS4av4 TUTORIAL

public class PlayerPickupDrop : MonoBehaviour
{


    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickupLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {      //Press e key to interact
        Debug.Log("Test 1");
        float pickupDistance = 2f;  //Distance from which you can pickup an item
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickupLayerMask)) {  //Going to use point of view of the First Person Camera
                 Debug.Log("Test 2");
                 if(raycastHit.transform.TryGetComponent(out ObjectGrabbable objectGrabbable)) { //Check if object has objectGrabbable script
                 objectGrabbable.Grab(objectGrabPointTransform);
                 Debug.Log("Test 3", objectGrabbable);
            }

        }
        }
        
        
    }
}
