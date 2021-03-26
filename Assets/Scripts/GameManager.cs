using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gM;



    PlayButton scriptButton;
    Generator scriptGenerator;

    
    

    [HideInInspector]
    public GameObject controllerSelected;
    public bool canBuild;
    public bool isPlaying;

    void Start()
    {
       gM = this;
       scriptButton = GetComponent<PlayButton>();
       scriptGenerator = GetComponent<Generator>();
       isPlaying = false;
       canBuild = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete) || Input.GetButton("X_button")) 
        {
            Delete(); // Destroy the actual controller selected
        }
        if (Input.GetButton("Lb") && isPlaying == false)
        {
            scriptButton.Play();
        }
        if (Input.GetButton("Rb") && isPlaying == true)
        {
            scriptButton.Stop();
        }
        if ( canBuild == true && Input.GetButtonDown("Y_button"))
        {
            InvockeController();
        }
    }

    public void Delete()
    {
        Destroy(controllerSelected);
        canBuild = true;
    }

    public void InvockeController()
    {
        scriptGenerator.SpawnController();
        canBuild = false;

    }

    
   
    
}
