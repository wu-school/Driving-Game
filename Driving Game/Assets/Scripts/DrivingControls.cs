using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingControls : MonoBehaviour
{
    [SerializeField] float acceration, torque, maxSpeed;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
            rb = GetComponent<Rigidbody2D>();
            acceration = 5;
            maxSpeed = 10;
            torque = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W) && rb.velocity.magnitude<maxSpeed){
            rb.velocity+=( rb.velocity.normalized*acceration/100);
        }  
        else if(Input.GetKey(KeyCode.S) && rb.velocity.magnitude<maxSpeed){
            rb.velocity*=( rb.velocity.normalized*-1*acceration/100);
        }
        
        if(Input.GetKey(KeyCode.D)){
            float turn = Input.GetAxis("Horizontal");
            rb.AddTorque(torque*turn*-1);
        } else if(Input.GetKey(KeyCode.A)){
            float turn = Input.GetAxis("Horizontal");
            rb.AddTorque(torque*turn);
        } else{
            
        }
        
    }
}
