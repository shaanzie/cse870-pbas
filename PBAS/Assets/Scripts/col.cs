using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class col : MonoBehaviour
{
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        GUI.Label(new Rect(0, 0, 500, 500), "Hello!");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
