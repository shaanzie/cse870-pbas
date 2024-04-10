using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GreenCar : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int speed;
    public float rotate;
    public static int interval;
    public static AudioSource beeper;
    public AudioClip beepclip;
    public string canvastag; 
    private Text distancetext; 

    public GreenCar()
    {
        speed = 1;
       
    }
    void Start()
    {
        GameObject distanceTextObject = GameObject.Find("DistanceText");
        Text distanceText = distanceTextObject.GetComponent<Text>();
        distanceText.text = "Pathway clear, watch for surrounding objects";
        beeper = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward*speed*Time.deltaTime);
            if(Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(0,-45*speed*Time.deltaTime,0);
            if(Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(0,45*speed*Time.deltaTime,0);
        }
            
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back*speed*Time.deltaTime);
            if(Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(0,-45*speed*Time.deltaTime,0);
            if(Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(0,45*speed*Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.Space) && speed ==0)
        {
            speed = 1;
            GameObject.Find("UIText").transform.localScale= new Vector3(0,0,0);
            GameObject.Find("UIText").transform.localScale= new Vector3(0,0,0);


        }

    }

    // Gets called when the object enters the collider area 
    void OnTriggerEnter(Collider objectName)
    {
        interval = 1;
        // Debug.Log(this + " entered collision with " + objectName.gameObject.name);
        if(Time.frameCount % interval == 0)
        {
            beeper.PlayOneShot(beepclip);
            GameObject distanceTextObject = GameObject.Find("DistanceText");
            Text distanceText = distanceTextObject.GetComponent<Text>();
            distanceText.text = "Pathway clear, watch for surrounding objects";
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
            GameObject distanceTextObject = GameObject.Find("DistanceText");
            Text distanceText = distanceTextObject.GetComponent<Text>();
            distanceText.text = "Pathway clear, watch for surrounding objects";
            Debug.Log(interval);
        }
    }

    // Gets called when the object exits the collider area
    void OnTriggerExit(Collider objectName)
    {
        // Debug.Log(this + " exited collision with " + objectName.gameObject.name);
        beeper.Pause();
        Debug.Log(interval);
    }

    public Color HexToColor(string hex)
    {
        if (hex.StartsWith("#"))
        {
            hex = hex.Substring(1);
        }
        float r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 255f;
        float g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber) / 255f;
        float b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber) / 255f;

        return new Color(r, g, b, 0.15f);
    }
}
