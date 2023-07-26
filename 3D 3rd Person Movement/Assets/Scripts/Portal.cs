using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] Transform player;


    void OnTriggerEnter(Collider other) {
        Debug.Log("Teleport");
        if (other.tag == "Player") 
        {
            Debug.Log("Teleport2");
            player.GetComponent<PlayerMovement>().Teleport(destination.position, destination.rotation);
            //player.Teleport(destination.position, destination.rotation);
        }
    }


    void OnDrawGizmos() {

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(destination.position, 2f);
        var direction = destination.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(destination.position, direction);
    }



}
