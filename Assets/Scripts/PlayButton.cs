using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
  
    public GameObject button;

    [Header("Material settings")]
    public Material playMaterial;
    public Material stopMaterial;

    Renderer renderButton;

    private void Start()
    {
        renderButton = button.GetComponent<Renderer>();
    }

    public void Stop()
    {
            GameManager.gM.isPlaying = false;

            renderButton.material = stopMaterial;
   
    }

    public void Play()
    {
            GameManager.gM.isPlaying = true;
   
            renderButton.material = playMaterial;
      
    }
}
