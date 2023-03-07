using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class boxTrigger : MonoBehaviour
{

    public GameObject txtToDisplay;            //display the UI text
    
    private bool PlayerInZone;                  //check if the player is in box collider

    int score; //Count number of items added to box

    [SerializeField] private Animator myAnimationController;



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

        //if Mushroom is placed in MushroomCounter box collider
        if (other.gameObject.tag == "Mushroom" && gameObject.tag == "MushroomCounter")     
        {
            txtToDisplay.SetActive(true);
            score = score + 1;
            PlayerInZone = true;
            // Debug.Log(txtToDisplay.GetComponent<UnityEngine.UI.Text>().text + " " + score); //Get the "Text" of the GameObject (This is getting the text of the UI element)
            txtToDisplay.GetComponent<UnityEngine.UI.Text>().text = "Score " + score.ToString();
            Debug.Log("Mushroom added to MushroomCounter Box Collider");
        }


    //When object hits Target
    if (other.gameObject.tag == "Mushroom" && gameObject.tag == "Target")     {

        Debug.Log("Target Hit");

        //Show brdige animation so player can proceed
        myAnimationController.Play("Bridge");
        gameObject.GetComponent<AudioSource>().Play();
        Debug.Log("Play Animation");

    }

     }
    
    //if Mushroom is removed from MushroomCounter box collider
    private void OnTriggerExit(Collider other)    
    {
        if (other.gameObject.tag == "Mushroom" && gameObject.tag == "MushroomCounter")
        {
            txtToDisplay.SetActive(true);
            PlayerInZone = false;
            score = score - 1;
            txtToDisplay.GetComponent<UnityEngine.UI.Text>().text = "Score " + score.ToString();
            if (score == 0) {
                 txtToDisplay.SetActive(false);     //TODO Dont show score pop-up when score = 0
            }

            Debug.Log("Mushroom removed from MushroomCounter Box Collider");

        }
    }
}