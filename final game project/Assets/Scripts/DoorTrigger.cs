using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    
 
     public GameObject door;

    private void onTriggerEnter(Collider other)
    {
        door.transform.position += new Vector3 (0,100,0);
    }
}
