using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueScript : MonoBehaviour
{

    //Defining the different elements of the TutorialNarrative
    public GameObject CanvasTutorialNarrative;
   
    //Defining the different elements of the TutorialControls
    public GameObject CanvasTutorialControls;

    public void ContinueButton() //Class for the continue button
    {
        CanvasTutorialNarrative.gameObject.SetActive(false); //Hides the story textbox
        CanvasTutorialControls.gameObject.SetActive(true); //Makes the controls textbox visible
    }
}
