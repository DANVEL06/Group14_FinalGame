using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoySpawnController : MonoBehaviour
{
    public GameObject decoy;
    
   

    public Transform spawnPos;
    private bool spawned;
    private float delay;

     public AudioSource decoySpawn;
    // Start is called before the first frame update
    void Start()
    {
        
        spawned = false;
        delay =5;

    }

    // Update is called once per frame
    void Update()
    {
        if(delay >=5 && Input.GetKey(KeyCode.LeftControl))
        {
            decoySpawn.Play();
           Instantiate (decoy, spawnPos.position, Quaternion.identity );
           delay = 0;
        }
        delay += Time.deltaTime;
    }
}
