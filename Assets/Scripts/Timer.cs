using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    
    float timer;
    public Text time;

    void Start()
    {
        //Initialize timer with value 0
        timer = 0;
      
    }

    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
        time.text = timer.ToString();
        
    }
}
