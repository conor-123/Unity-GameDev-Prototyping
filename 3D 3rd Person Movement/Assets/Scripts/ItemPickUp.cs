using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, IInteractable {
    
    [SerializeField] private string interactText;
    


    public void Interact(Transform interactorTransform) {
     
       Debug.Log("Item Pickup");

    
    }



    public void PickUp() {
        Debug.Log("Pick up item");
    }




    public string GetInteractText() {
        return "Pick Up Item";
    }

    public Transform GetTransform() {
        return transform;
    }


}
