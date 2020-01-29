using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public GameObject player;//за кем следим
    private Rigidbody2D rb2d;//
    // Start is called before the first frame update
    void Start()
    {
        rb2d = player.GetComponent<Rigidbody2D>();//из риджитбоди будет браться вектор скорости
    }

    
    void LateUpdate()
    {
        //transform.position = player.transform.position;//двигаем стрелку вместе с кораблем
        
        transform.eulerAngles -= new Vector3(0, 0, Vector2.SignedAngle(rb2d.velocity.normalized, transform.up.normalized));//поворачиваем
    }
}
