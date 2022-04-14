using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    float currentTime;
    public int startMinutes;
    public Text currentTimeText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if ( timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
   // public void StartTimer()
    //{
      //  timerActive = true;
    //}
//    public void StopTimer()
    //{
       // timerActive = false;
    //}
    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            timerActive = true;
        }
    }
    
}
