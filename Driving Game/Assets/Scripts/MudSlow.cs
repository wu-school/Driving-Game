using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudSlow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
            DrivingControls carScript = other.gameObject.GetComponent<DrivingControls>();
            carScript.setMud();
            Debug.Log("entered mud");
    }
    private void OnTriggerExit2D(Collider2D other) {
            DrivingControls carScript = other.gameObject.GetComponent<DrivingControls>();
            carScript.exitMud();
            Debug.Log("exited mud");
    }
}
