using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonUI : GreenCar
{

    public void LoadSceneByName(string sceneName)
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    void DisplayText()
    {
        GameObject distanceTextObject = GameObject.Find("DistanceCanvas");
        Text distanceText = distanceTextObject.GetComponentInChildren<Text>();
        int counter = 0;
        distanceText.text = "Updates installing, Automatic Braking may not be functional. Proceed with caution.";
        if(Input.GetKey(KeyCode.Space))
            distanceText.text = "Pathway clear, watch for surrounding objects";

    }
}
