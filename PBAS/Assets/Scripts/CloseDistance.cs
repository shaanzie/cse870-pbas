using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CloseDistance : GreenCar
{

    // Start is called before the first frame update
    void Start()
    {
        beeper = GetComponent<AudioSource>();
        GameObject.Find("UIText").transform.localScale= new Vector3(0,0,0);

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Gets called when the object enters the collider area 
    void OnTriggerEnter(Collider objectName)
    {
        interval = 30;
        // Debug.Log(this + " entered collision with " + objectName.gameObject.name);
        if(Time.frameCount % interval == 0)
        {
            beeper.PlayOneShot(beepclip);
            Debug.Log(interval);
        }
        
        GreenCar car = GameObject.Find("WGX_EGG_CAR_01_GREEN").GetComponent<GreenCar>();
        car.speed = 0;
        GameObject.Find("UIText").transform.localScale= new Vector3(1,1,1);
        GameObject distanceTextObject = GameObject.Find("DistanceCanvas");
        objectName.gameObject.GetComponentInChildren<Renderer>().material.color = HexToColor("FF0900");

        Text distanceText = distanceTextObject.GetComponentInChildren<Text>();
        distanceText.text = "Object detected in CD!";


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
            distanceText.text = "Object detected in CD!";
            objectName.gameObject.GetComponentInChildren<Renderer>().material.color = HexToColor("FF0900");
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
