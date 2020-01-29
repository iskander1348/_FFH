using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public GameObject point;//точка, оставляющая след
    public int Delay = 3;//задержка между следами
    public float StepsLifetime = 3;//сколько секунд держится след
    private int iterator;


    void Start()
    {
        iterator = 0;
    }
    
    void Update()
    {
        
        // Add the time since Update was last called to the timer.
        iterator += Mathf.RoundToInt(Time.timeScale);

        if (iterator == Delay)
        {
            Destroy(Instantiate(point, transform.position, Quaternion.identity), StepsLifetime);//создает точку следа, которая уничтожается через задержку
            iterator = 0;
        }


    }//*/
}
