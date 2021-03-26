using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gM;
    


    [HideInInspector]
    public GameObject controllerSelected;
    public bool canBuild;
    public bool isPlaying;

    void Start()
    {
        gM = this;

      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete) || Input.GetButton("X_button")) 
        {
            Delete(); // Destroy the actual controller selected
        }


        if (Input.GetButton("Lb"))
        {
            PlayButton scriptButton = GetComponent<PlayButton>();

            scriptButton.Play();

        }
    }

    public void Delete()
    {
        Destroy(controllerSelected);
        canBuild = true;
    }

    
   
    
}
