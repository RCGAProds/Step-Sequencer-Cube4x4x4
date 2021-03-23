using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject prefabBall;
    public Transform spawnPoint;

    public void SpawnController () //Generate a Controller if the condition is true
    {
        if(Time.timeScale == 1 && GameManager.gM.canBuild)
        {
            Instantiate(prefabBall, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
