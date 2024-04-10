using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class FarDistance : GreenCar
{

    // Start is called before the first frame update
    void Start()
    {
        beeper = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Gets called when the object enters the collider area 
    void OnTriggerEnter(Collider objectName)
    {
        interval = 100;
        // Debug.Log(this + " entered collision with " + objectName.gameObject.name);
        if(Time.frameCount % interval == 0)
        {
            beeper.PlayOneShot(beepclip);
            GameObject distanceTextObject = GameObject.Find("DistanceCanvas");
            Text distanceText = distanceTextObject.GetComponentInChildren<Text>();
            distanceText.text = "Object detected in FD!";
            objectName.gameObject.GetComponentInChildren<Renderer>().material.color = HexToColor("00FF17");
            Debug.Log(interval);
        }
    }

    // Gets called during the stay of object inside the collider area
    void OnTriggerStay(Collider objectName)
    {
        // Debug.Log(this + " colliding with " + objectName.gameObject.name);
        if(Time.frameCount % interval == 0)
        {
            beeper.PlayOneShot(beepclip);
            GameObject distanceTextObject = GameObject.Find("DistanceCanvas");
            Text distanceText = distanceTextObject.GetComponentInChildren<Text>();
            distanceText.text = "Object detected in FD!";
            objectName.gameObject.GetComponentInChildren<Renderer>().material.color = HexToColor("00FF17");
            Debug.Log(interval);
        }
    }

    // Gets called when the object exits the collider area
    void OnTriggerExit(Collider objectName)
    {
        // Debug.Log(this + " exited collision with " + objectName.gameObject.name);
        beeper.Pause();
        GameObject distanceTextObject = GameObject.Find("DistanceText");
        Text distanceText = distanceTextObject.GetComponent<Text>();
        distanceText.text = "Pathway clear, watch for surrounding objects";
        objectName.gameObject.GetComponentInChildren<Renderer>().material.color = HexToColor("00FF17");
        Debug.Log(interval);
    }

}
