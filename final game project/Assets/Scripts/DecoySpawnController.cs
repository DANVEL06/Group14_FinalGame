using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoySpawnController : MonoBehaviour
{
    public GameObject decoy;
    
   

    public Transform spawnPos;
    private bool spawned;
    private float delay;
    // Start is called before the first frame update
    void Start()
    {
        
        spawned = false;
        delay =3;

    }

    // Update is called once per frame
    void Update()
    {
        if(delay >=3 && Input.GetKey(KeyCode.LeftControl))
        {
           Instantiate (decoy, spawnPos.position, Quaternion.identity );
           delay = 0;
        }
        delay += Time.deltaTime;
    }
}
