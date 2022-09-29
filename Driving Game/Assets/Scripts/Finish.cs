using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
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
        Debug.Log("entered finish");
        GameObject myCanvas = GameObject.Find("Canvas");
        myCanvas.GetComponent<Canvas>().enabled = true;

        GameObject[] lightList = GameObject.FindGameObjectsWithTag("Light");
        for(int i = 0; i<lightList.Length; i++){
            Debug.Log("enabling particles");
            var myemission = lightList[i].GetComponent<ParticleSystem>().emission;
            myemission.enabled = true;
        }

    }
}
