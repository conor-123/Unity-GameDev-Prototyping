using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class boxTrigger : MonoBehaviour
{

    public GameObject txtToDisplay;            //display the UI text
    
    private bool PlayerInZone;                  //check if the player is in box collider

    int score; //Count number of items added to box

    

    






     

    //When scene starts - check if player is in the box coliider

    private void Start()
    {


        PlayerInZone = false;                   //player not in zone    
        Debug.Log(txtToDisplay.GetComponent<UnityEngine.UI.Text>().text + " " + score); //Get the "Text" of the GameObject (This is getting the text of the UI element)
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.F))           //if in zone and press F key
        {

            
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("switch");
           
        }
    }


    //Display text if Mushroom is added is in box collider

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mushroom")     //if mushroom is placed in box
        {
            txtToDisplay.SetActive(true);
            score = score + 1;
            PlayerInZone = true;
            Debug.Log(txtToDisplay.GetComponent<UnityEngine.UI.Text>().text + " " + score); //Get the "Text" of the GameObject (This is getting the text of the UI element)
            txtToDisplay.GetComponent<UnityEngine.UI.Text>().text = "Score " + score.ToString();
            
        }


     }
    

    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.tag == "Mushroom")
        {
            txtToDisplay.SetActive(true);
            PlayerInZone = false;
            score = score - 1;
            txtToDisplay.GetComponent<UnityEngine.UI.Text>().text = "Score " + score.ToString();
            if (score == 0) {
                 txtToDisplay.SetActive(false);     //Dont show score pop-up when score = 0
            }

        }
    }
}