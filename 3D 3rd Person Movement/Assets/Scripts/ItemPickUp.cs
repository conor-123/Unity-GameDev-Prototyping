using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, IInteractable {
    
    [SerializeField] private string interactText;
    


    public void Interact(Transform interactorTransform) {
     
        PickUp();

    
    }



    public void PickUp() {
        //TODO - Add pick up object code here, also make separate drop function
        Debug.Log("Pick up item!");
    }




    public string GetInteractText() {
        return "Pick Up Item";
    }

    public Transform GetTransform() {
        return transform;
    }


}
