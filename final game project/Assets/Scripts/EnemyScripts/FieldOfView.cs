using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
   public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;
    public GameObject decoyRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    public bool seeDecoy;

    public GameObject bullet;
    public Transform shootPoint;
     public float shootSpeed = 10f;
    public float timeToShoot = 1.3f;
    float originalTime;
    public Transform enemy;

    private void Start()
    {
        originalTime=timeToShoot;
        playerRef = GameObject.FindGameObjectWithTag("PlayerModel");
        StartCoroutine(FOVRoutine());
    }
    void Update()
    {
        findDecoy();
        if(canSeePlayer)
        {
            if(seeDecoy)
            {
                enemy.LookAt(decoyRef.transform);
            }
            else
            {
                enemy.LookAt(playerRef.transform);
            }
        }
        
    }

    private void FixedUpdate()
    {
        if(canSeePlayer)
        {
            timeToShoot -= Time.deltaTime;

            if(timeToShoot < 0 )
            {
                ShootPlayer();
                timeToShoot = originalTime;
            }
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
     private void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();

        rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }
    void findDecoy()
    {
        if(GameObject.FindGameObjectWithTag("PlayerDecoy")== null)
        {
            seeDecoy = false;
            return;
            
        }
        else
        {
            decoyRef =GameObject.FindGameObjectWithTag("PlayerDecoy");
            seeDecoy = true;
        }
    }
}
