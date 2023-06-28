using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable {

    [SerializeField] private string interactText;

    private Animator animator;
  //  private NPCHeadLookAt npcHeadLookAt;

   PlayerInteractUI playerUI;

    private void Awake() {
        animator = GetComponent<Animator>();
     //   npcHeadLookAt = GetComponent<NPCHeadLookAt>();
    }

    public void Interact(Transform interactorTransform) {
     // ChatBubble3D.Create(transform.transform, new Vector3(-.3f, 1.7f, 0f), ChatBubble3D.IconType.Happy, "Hello there!");
       Debug.Log("Test111");

      //TO DO Display Text from NPC and also remove E button UI after pressing it



       

        //animator.SetTrigger("Talk");

        //float playerHeight = 1.7f;
     //   npcHeadLookAt.LookAtPosition(interactorTransform.position + Vector3.up * playerHeight);
    }

    public string GetInteractText() {
        return interactText;
    }

    public Transform GetTransform() {
        return transform;
    }

}