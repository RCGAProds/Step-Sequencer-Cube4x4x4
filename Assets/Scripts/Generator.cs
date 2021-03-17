using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject prefabBall;
    public Transform spawnPoint;

    public void SpawnController ()
    {
        if(Time.timeScale == 1)
        {
            Instantiate(prefabBall, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
