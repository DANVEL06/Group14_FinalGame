using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionScript : MonoBehaviour
{
    //public float slowMotionTimeScale;

    //private float startTimeScale;
   // private float startFixedDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        //startFixedDeltaTime = Time.timeScale;
        //startFixedDeltaTime = Time.fixedDeltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartSlowMotion();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopSlowMotion();
        }
    }

    void StartSlowMotion()
    {
        Time.timeScale = Mathf.Lerp(1,0.1f,5);
    }

    void StopSlowMotion()
    {
        Time.timeScale = Mathf.Lerp(0.1f, 1,5);
    }
}
