using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tocombatroom : MonoBehaviour
{
     private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Combat Cut Scene");
        }
    }
}
