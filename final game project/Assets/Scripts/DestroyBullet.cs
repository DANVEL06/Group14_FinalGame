using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "PlayerDecoy"|| collision.gameObject.tag == "PlayerBullet"|| collision.gameObject.tag == "EnemyBuller" || collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject,3f);
        }
    }

    
}
