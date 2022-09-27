using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingControls : MonoBehaviour
{
    [SerializeField] float acceration, torque, maxSpeed, speed, maxAngularVelocity;
    public bool grass,track,mud;
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
        
        if(mud){
            maxSpeed = 0.95f;
            rb.drag = 0.4f;
        } else if(grass && !track){
            maxSpeed = 3f;
            rb.drag = 0.4f;
        } else if(track && !mud) {
            maxSpeed = 6.95f;
            rb.drag = 0;
        }              
        
    }
    public void setMud(){
        
    }
    public void setGrass(){
        maxSpeed = Mathf.Min(maxSpeed, 3);
        rb.drag = 0.4f;
    }
    public void exitMud(){
        maxSpeed = 6.95f;
        rb.drag = 0;
    }
    public void exitGrass(){
        maxSpeed = 6.95f;
        rb.drag = 0;
    }

    private void OnGUI() {  
        GUI.Label(new Rect(0,0,150,30), "Speed " + Mathf.RoundToInt(speed*100));
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Grass")){
            grass = true;
        } else{
            grass = false;
        }
        if(other.gameObject.tag.Equals("Mud")){
            mud = true;
        } else{
            mud = false;
        }
        if(other.gameObject.tag.Equals("Track")){
            track = true;
        } else{
            track = false;
        }
    }
}
