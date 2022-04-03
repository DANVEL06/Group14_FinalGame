using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPos;
    public float shootSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           Shoot();
        }
    }

    private void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, shootPos.position, shootPos.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();

        rig.AddForce(shootPos.forward * shootSpeed, ForceMode.Impulse);
    }
}
