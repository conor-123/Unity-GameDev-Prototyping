using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;

    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    private void Awake() {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    
    public void Grab(Transform objectGrabPointTransform) {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;     //set gravity of object to false , this will stop it from constantly trying to fall up and down
        objectRigidbody.angularVelocity = new Vector3(0,0); //Set pre existing angular velocity to 0 to stop object from rotating
        objectRigidbody.velocity = new Vector3(0,0); //Set pre existing velocity to 0 to stop item pulling up and down towards the ground
        

    }

    // Throw object
    
    public void Throw(){
        //For individual throwable items, make sure to attach "Main Camera" to  "Player Camera Transform" in the object grabbable script area in Unity
        Debug.Log("Left Click Test");
        objectRigidbody.AddForce(playerCameraTransform.transform.forward * 1000); // Add force and throw item in the direction that the camera is facing

    }

    public void Drop() {
        this.objectGrabPointTransform = null;   
        objectRigidbody.useGravity = true;  //Set gravity again to allow object to fall
    }


    private void Update() {

        if(objectGrabPointTransform != null) {
            float lerpSpeed = 40f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);    //Will create a smooth motion when moving currently grabbed object
            objectRigidbody.MovePosition(newPosition);


        }

    }



}
