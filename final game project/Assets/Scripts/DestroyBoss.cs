using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DestroyBoss : MonoBehaviour
{
    public int health=2;
    
    FieldOfView view;
    public AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
       if (health <2)
        SceneManager.LoadScene("WinScreen");
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            hit.Play();
            health--;
            view.canSeePlayer = true;
          
           
            
        }
    }
}
