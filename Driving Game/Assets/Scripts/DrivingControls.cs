using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingControls : MonoBehaviour
{
    [SerializeField] float acceration, torque, maxSpeed, speed, maxAngularVelocity;
    [SerializeField] public int[] booleans = {0, 0, 0};
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
        changeSurface();
        torque = speed*0.5f;

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
            if(Input.GetKey(KeyCode.D) && -1*rb.angularVelocity<maxAngularVelocity){
                float turn = Input.GetAxis("Horizontal");
                rb.AddTorque(torque*turn);
            } else if(Input.GetKey(KeyCode.A) && rb.angularVelocity<maxAngularVelocity){
                float turn = Input.GetAxis("Horizontal");
                rb.AddTorque(torque*turn);
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
    private void OnGUI() {  
        GUI.Label(new Rect(0,0,150,30), "Speed " + Mathf.RoundToInt(speed*100));
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Grass")){
            booleans[2]++;
        } else{
        }
        
        if(other.gameObject.tag.Equals("Mud")){
            booleans[0]++;
            return;
        } else{
        }
        if(other.gameObject.tag.Equals("Track")){
            booleans[1]++;
            return;
        } else{
        }
    }

    private void changeSurface(){
        if(booleans[0]>0){
            maxSpeed = 0.95f;
            rb.drag = 0.4f;
          //  Debug.Log("in mud");
        } else if(booleans[1]>0){
            maxSpeed = 6.95f;
            rb.drag = 0;
           // Debug.Log("on track");
        } else {
            maxSpeed = 3f;
            rb.drag = 0.4f;
           // Debug.Log("in grass");
        }

        booleans[0] = 0;
        booleans[1] = 0;
        booleans[2] = 0;   
    }
}
