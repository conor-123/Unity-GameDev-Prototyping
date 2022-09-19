using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{

    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    private void Awake() {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    
    public void Grab(Transform objectGrabPointTransform) {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;     //set gravity of object to false , this will stop it from constantly trying to fall up and down

    }

    public void Drop() {
        this.objectGrabPointTransform = null;   
        objectRigidbody.useGravity = true;  //Set gravity again to allow object to fall
    }


    private void FixedUpdate() {

        if(objectGrabPointTransform != null) {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);    //Will create a smooth motion when moving currently grabbed object
            objectRigidbody.MovePosition(newPosition);


        }

    }



}
