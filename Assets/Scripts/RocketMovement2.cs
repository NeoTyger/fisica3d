using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RocketMovement2 : MonoBehaviour
{
    private int maxSpeed = 5;

    private float elevation;

    private float fuel = 10;
    
    private float throatSpeed = 300f;

    [SerializeField] private float gravity;

    [SerializeField] private float velocity;

    private float positionY;

    [SerializeField] TextMeshProUGUI text_Speed;
    [SerializeField] TextMeshProUGUI text_MaxSpeed;
    [SerializeField] TextMeshProUGUI text_Elevation;
    [SerializeField] TextMeshProUGUI text_Fuel;
    [SerializeField] TextMeshProUGUI text_GameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        text_GameOver.gameObject.SetActive(false);
        text_MaxSpeed.text = "Max Speed : " + maxSpeed;
        text_Fuel.text = "Fuel : " + fuel;
    }

    // Update is called once per frame
    void Update()
    {
        elevation = transform.position.y;
        text_Elevation.text = "Elevation : " + elevation.ToString("F1");
        
        velocity = velocity + gravity * Time.deltaTime ;
        text_Speed.text = "Speed : " + velocity.ToString("F1");

        
        //Por pulsaciones
        
        /*if (Input.GetKeyDown(KeyCode.Space) && fuel > 0)
        {
            rb.velocity = rb.velocity + new Vector3(0,5,0);
            fuel--;
            text_Fuel.text = "Fuel : " + fuel;
        }*/
        
        //Mantener pulsado

        if (Input.GetKey(KeyCode.Space) && fuel > 0f)
        {
            velocity = velocity * 3;
            fuel = fuel - 2 * Time.deltaTime;
            text_Fuel.text = "Fuel : " + fuel.ToString("F1");
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (velocity > maxSpeed)
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
