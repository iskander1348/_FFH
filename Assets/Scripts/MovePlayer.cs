using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovePlayer : MonoBehaviour
{
    public float Speed;             //Floating point variable to store the player's movement speed.
    public float StartSpeed;
    public float FuelAmount = 10;
    public Image fuel;
  //  public float RotationForce; //сила поворота
/*
    public Scrollbar Throat;    //тяга, тянем со слайдбара
    public Toggle Autocorrection;
    public Slider Yaw;
   // */
    public GameObject compas;
    
        //Vector3 StartClick = Vector3.zero;
    float Angle = 0;//угол отклонения от тяги, по умолчанию 0
    public Text speed;
    bool turn;
    float comsumption;
    
    //bool Correction = Autocorrection.isOn;




    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private ParticleSystem boost;
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();//инициализируем  риджитбоди
        boost = GetComponent<ParticleSystem>();
        rb2d.AddForce(transform.up * StartSpeed);//небольшой толчок вперед
        compas.SetActive(false);
        turn = false;
        comsumption = 1 / FuelAmount;
    }
    /*
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

       // rb2d.AddForce(transform.up * Speed * Throat.value);//добавляем тягу
        
        

       // transform.eulerAngles -= new Vector3(0, 0, (Angle + Rotation) * RotationForce);//поворачиваем

        /*

        float Rotation = Input.GetAxis("Horizontal");//снимаем поворот с кнопок

        //Store the current vertical input in the float moveVertical.
        //float throat = Input.GetAxis("Vertical");
        // Debug.Log(transform.eulerAngles);


        /*
        if (Prograde.isOn)
       
            
            Angle = Vector2.SignedAngle(rb2d.velocity.normalized, transform.up.normalized) / 180;
         
        if (Retrograde.isOn)
        
            
            Angle = Vector2.SignedAngle(rb2d.velocity.normalized, -transform.up.normalized) / 180;
          
      
         if (Mathf.Abs(Angle) < 0.01)
            
         {
            Prograde.isOn = false;
            Retrograde.isOn = false;

        }//*/
        // Debug.Log(TurnRetrograde);
        //   
        //направление по повотору спрайта, скорость из значения скролбара
        /*

        transform.eulerAngles -= new Vector3(0, 0, (Angle + Rotation) * RotationForce);//поворачиваем
        //суммируем автоповорот и поворот с кнопок, скорость поворота из переменной
        
        //Debug.Log(Angle);//

    }//*/
    private void LateUpdate()
    {
        speed.text = rb2d.velocity.magnitude.ToString();
        Angle = Vector2.SignedAngle(rb2d.velocity.normalized, transform.up.normalized)/180;
        if (!turn)
             transform.eulerAngles -= new Vector3(0, 0, Angle);
        // float Rotation = Yaw.value;
      }
    
    private void Update()
    {
        


        if (Input.GetButtonDown("Fire1"))//при нажатии
        {
            Time.timeScale = 0;//замедляем время
            //StartClick = Input.mousePosition;//и запоминаем точку нажатия
            compas.SetActive(true);
            turn = true;

           // Debug.Log(Vector2.SignedAngle(Pos.normalized, Vector3.up));
        }
            


        if (Input.GetButtonUp("Fire1"))//когда кнопка отжата
        {   
            Time.timeScale = 1f;//возвращаем время в норму
            if (fuel.fillAmount > 0)
            {
                //Debug.Log(comsumption);
                boost.Play();
                fuel.fillAmount -= comsumption;
                rb2d.AddForce(transform.up * Speed);//и запускаем как из рогатки//* (StartClick - Input.mousePosition).magnitude

            }
            compas.SetActive(false);
            turn = false;
            //Debug.Log((StartClick - Input.mousePosition).magnitude);
        }
            
        if (turn)
        {
            Vector3 Pos = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0);
            //смотрим позицию курсора относительно центра экрана
            transform.eulerAngles = new Vector3(0, 0, -Vector2.SignedAngle(Pos.normalized, -Vector3.up));
            //и поворачиваем спрайт, не забывая повернуть угол, чтобы нажатие было за кораблем
        }

        // 
        // Debug.Log();//-transform.position);
    }
    //*/
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Planetoid")
        {
            //fuel.fillAmount = 0;
            Destroy(this);
        }//*
    }


}

