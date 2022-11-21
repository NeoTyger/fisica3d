using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    private Rigidbody rb;

    private int maxSpeed = 5;

    private float elevation;

    private float speed;

    private float fuel = 10;
    
    private float throatSpeed = 300f;

    [SerializeField] TextMeshProUGUI text_Speed;
    [SerializeField] TextMeshProUGUI text_MaxSpeed;
    [SerializeField] TextMeshProUGUI text_Elevation;
    [SerializeField] TextMeshProUGUI text_Fuel;
    [SerializeField] TextMeshProUGUI text_GameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        text_GameOver.gameObject.SetActive(false);
        
        rb = this.gameObject.GetComponent<Rigidbody>();
        text_MaxSpeed.text = "Max Speed : " + maxSpeed;
        text_Fuel.text = "Fuel : " + fuel;
    }

    // Update is called once per frame
    void Update()
    {
        //Mirar de como pasar de float a int
        elevation = rb.position.y;
        text_Elevation.text = "Elevation : " + elevation.ToString("F1");
        
        speed = - rb.velocity.y; //Es menos rb.velocity.y para que salga la velocidad positiva en pantalla ya que es negativa por que cae
        text_Speed.text = "Speed : " + speed.ToString("F1");

        
        //Por pulsaciones
        
        /*if (Input.GetKeyDown(KeyCode.Space) && fuel > 0)
        {
            //rb.AddForce(Vector3.up * throatSpeed);
            rb.velocity = rb.velocity + new Vector3(0,5,0);
            fuel--;
            text_Fuel.text = "Fuel : " + fuel;
        }*/
        
        //Mantener pulsado

        if (Input.GetKey(KeyCode.Space) && fuel > 0f)
        {
            //rb.AddForce(Vector3.up * throatSpeed);
            rb.velocity = rb.velocity + new Vector3(0,30f * Time.deltaTime,0);
            fuel = fuel - 2 * Time.deltaTime;
            text_Fuel.text = "Fuel : " + fuel.ToString("F1");
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (speed > maxSpeed)
        {
            GameOver("YOU LOSE");
        }
        else
        {
            GameOver("YOU WIN");
        }
    }

    private void GameOver(string msg)
    {
        text_GameOver.gameObject.SetActive(true);
        text_GameOver.text = msg;
    }
}
