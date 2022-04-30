using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DestroyEnemy : MonoBehaviour
{
    public int health=10;
    public int playerScore =0;
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
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            hit.Play();
            health--;
            view.canSeePlayer = true;
          
            
            if(health <= 0)
            {
                playerScore ++;

                if(playerScore >=7)
                {
                    SceneManager.LoadScene(3);
                }
                else
                {
                    Destroy(gameObject);
                }
                
            }
        }
    }
}
