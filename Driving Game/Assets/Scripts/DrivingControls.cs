using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingControls : MonoBehaviour
{
    [SerializeField] float acceration, torque, maxSpeed, speed, maxAngularVelocity;
    bool grass,track,mud;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
            rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = rb.velocity.magnitude;
        
        if (Vector2.Dot(rb.velocity, transform.up)>0){
            if(Input.GetKey(KeyCode.D) && rb.angularVelocity<maxAngularVelocity){
                float turn = Input.GetAxis("Horizontal");
                rb.AddTorque(torque*turn*-1);
            } else if(Input.GetKey(KeyCode.A) && -1*rb.angularVelocity<maxAngularVelocity){
                float turn = Input.GetAxis("Horizontal");
                rb.AddTorque(torque*turn*-1);
            } else{
                rb.angularVelocity = 0;
            }
        }
        else{
            if(Input.GetKey(KeyCode.D) && rb.angularVelocity<maxAngularVelocity){
                float turn = Input.GetAxis("Horizontal");
                rb.AddTorque(torque*turn*-1);
            } else if(Input.GetKey(KeyCode.A) && -1*rb.angularVelocity<maxAngularVelocity){
                float turn = Input.GetAxis("Horizontal");
                rb.AddTorque(torque*turn*-1);
            } else{
                rb.angularVelocity = 0;
            }
        }

        if(Input.GetKey(KeyCode.W) && speed<maxSpeed){
            Vector2 deltaV = transform.up*acceration/100;
            rb.velocity+=deltaV;
        }  
        else if(Input.GetKey(KeyCode.S) && speed>0 && speed<maxSpeed){
            Vector2 deltaV = transform.up*acceration/100;
            rb.velocity-=deltaV;
        } else if (Vector2.Dot(rb.velocity, transform.up)>0){
            rb.velocity = transform.up*speed;
        } else {
            rb.velocity = -transform.up*speed;
        }
        
    }
    public void setMud(){
        maxSpeed = 1;
        rb.drag = 0.4f;
    }
    public void setGrass(){
        maxSpeed = Mathf.Min(maxSpeed, 3);
        rb.drag = 0.4f;
    }
    public void exitMud(){
        maxSpeed = 7;
        rb.drag = 0;
    }
    public void exitGrass(){
        maxSpeed = 7;
        rb.drag = 0;
    }
}
