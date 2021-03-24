using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    
    public void play()
    {


        if (GameManager.gM.isPlaying == true)
        {
            GameManager.gM.isPlaying = false;
        }
        else
        {
            GameManager.gM.isPlaying = true;
        }
    }
}
