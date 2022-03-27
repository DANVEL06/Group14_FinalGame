using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporttocombatroom : MonoBehaviour
{
   MovementStateManager playerController;
   void Start()
   {
     playerController = gameObject.GetComponent<MovementStateManager>();
   }
  void Update()
  {
     if(Input.GetKey(KeyCode.E))
     {
        StartCoroutine("Teleport");
     }
  }

  IEnumerator Teleport()
  {
        playerController.disabled = true;
        yield return new WaitForSeconds(0.01f);
        gameObject.transform.position = new Vector3(36.69f, 1.4f, 59.8f);
        yield return new WaitForSeconds(0.01f);
        playerController.disabled = false;
  }
}
