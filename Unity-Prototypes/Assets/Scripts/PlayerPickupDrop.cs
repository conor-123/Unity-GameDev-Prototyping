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

    private ObjectGrabbable objectGrabbable; //Keep track of currently held object

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {      //Press e key to interact
        if (objectGrabbable == null) { 
            //Not carrying an object, try to grab
        float pickupDistance = 5f;  //Distance from which you can pickup an item
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickupLayerMask)) {  //Going to use point of view of the First Person Camera
                 if(raycastHit.transform.TryGetComponent(out objectGrabbable)) { //Check if object has objectGrabbable script
                 objectGrabbable.Grab(objectGrabPointTransform);
            }
            }
            
            

        }
        
        else {
                //Currently carrying something, drop
                objectGrabbable.Drop(); //Call drop method from ObjectGrabbale
                objectGrabbable = null; //Set back to null as no longer carrying object
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            //Throw object when left mouse button is pressed
            //Change velocity and leave go o item
            objectGrabbable.Drop();
            objectGrabbable.Throw();          
        }
        
    }
}
