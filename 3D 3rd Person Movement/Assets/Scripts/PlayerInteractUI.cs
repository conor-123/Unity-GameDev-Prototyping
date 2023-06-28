using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInteractUI : MonoBehaviour {

    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;

    private void Update() {
        if (playerInteract.GetInteractableObject() != null) {
            Show();
        } else {
            Hide();
        }
    }

    private void Show() {
        containerGameObject.SetActive(true);
    }

    private void Hide() {
        containerGameObject.SetActive(false);
    }

}