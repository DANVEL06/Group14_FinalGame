using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinOrLose : MonoBehaviour
{
    
    public float currentHealth;
    public int score = 0;
     public AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            hit.Play();
            currentHealth--;
            if(currentHealth <= 0)
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }
    }
    
}