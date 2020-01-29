using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{
    public float mass;//масса передается как отдельная переменная
    //если использовать массу из риджитбоди начинаются глюки с вращением
   


    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {

        if (!other.gameObject.CompareTag("Planetoid"))
        {
            Vector2 movement = new Vector2(0, 0);//вектор каждый раз пересчитывается, начиная с нуля
            movement = other.transform.position - transform.position;//ищем вектор, куда нужно двигаться
            //Debug.Log(other);

            other.attachedRigidbody.AddForce(-movement.normalized * (other.attachedRigidbody.mass * mass) / (movement.magnitude * movement.magnitude));//добавляем силу
                                                                                                                                                       //Debug.Log(movement.magnitude);
                                                                                                                                                       //направление нормализуем, силу считаем по формуле, из масс и расстояния(магнитуды), игнорируя гравитационную постоянную
        }
        }
}
