using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gM;

    [HideInInspector]
    public GameObject controllerSelected;
    public bool canBuild;

    void Start()
    {
        gM = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(controllerSelected);
        }
    }

    public void Delete()
    {
        Destroy(controllerSelected);
    }
}
