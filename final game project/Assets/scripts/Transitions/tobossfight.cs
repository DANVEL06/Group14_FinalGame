using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tobossfight : MonoBehaviour
{
     private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Boss Cut Scene");
        }
    }
}
