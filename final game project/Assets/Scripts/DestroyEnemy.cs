using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DestroyEnemy : MonoBehaviour
{
    public int health=10;
    public int playerScore =0;
    FieldOfView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            health--;
            view.canSeePlayer = true;
            view.ShootPlayer();
            
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
