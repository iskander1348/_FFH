using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounding : MonoBehaviour
{
    public GameObject Anchor;//от чего вращается
    private float Radius;//радиус
    public float RotationPeriod;//период поворота
    // Start is called before the first frame update
    private Vector3 Position;//техническая переменная, записывается позиция
    void Start()
    {
        //transform.position = Anchor.transform.position + new Vector3(Radius, 0, 0); //задаем начальную позицию
        //TODO:
        //задавать начальную позицию
        Radius = (transform.position - Anchor.transform.position).magnitude;

       // Debug.Log(Radius);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Position = (transform.position - Anchor.transform.position);//записываем позицию в переменную
        //начало расчета новой координаты через матрицу поворота
       Position.x =Position.x * Mathf.Cos(1 / RotationPeriod) +Position.y * Mathf.Sin(1 / RotationPeriod);
       Position.y = -Position.x * Mathf.Sin(1 / RotationPeriod) +Position.y * Mathf.Cos(1 / RotationPeriod);
        //конец расчета
        //TODO: добавить возможность поворота против часовой стрелки
      //  Debug.Log(Anchor.transform.position);
        transform.position = Position + Anchor.transform.position;//применяем новую позицию
        //т.к. почему-то движение идет по суживающейся спирали, небольшой хак
        Position = transform.position - Anchor.transform.position;//смотрим смещение относительно якоря
        transform.position *= Radius / Position.magnitude;//и домножаем вектор позиции на нужное число
        //Debug.Log(Position.magnitude);


    }
}
