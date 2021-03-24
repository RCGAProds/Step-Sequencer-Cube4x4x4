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
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Delete();
        }

    }

    public void Delete()
    {
        Destroy(controllerSelected);
    }


   
    
}
