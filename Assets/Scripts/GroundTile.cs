using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.AddPoint();
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
        Destroy(this);
    }

    //private void OnTriggerExit(Collider other)
   // {
      //  groundSpawner.SpawnTile();
       // Destroy(gameObject, 2);
   // }
}