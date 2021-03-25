using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Text playtext;
    public GameObject button;

    [Header("Material settings")]
    public Material playMaterial;
    public Material stopMaterial;

    Renderer renderButton;

    private void Start()
    {
        renderButton = button.GetComponent<Renderer>();
    }

    public void Play()
    {


        if (GameManager.gM.isPlaying == true)
        {
            GameManager.gM.isPlaying = false;
            playtext.text = "Play";
            renderButton.material = stopMaterial;
            
            
        }
        else
        {
            GameManager.gM.isPlaying = true;
            playtext.text = "Stop";
            renderButton.material = playMaterial;
        }
    }
}
