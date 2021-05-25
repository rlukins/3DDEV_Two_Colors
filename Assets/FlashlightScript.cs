using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    public Light flash;
    bool isTurnedOn = false;
    void Start()
    {

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) {
            isTurnedOn = !isTurnedOn;
            turnOnOff(isTurnedOn);
        }
    }

    private void turnOnOff(bool onoff) {
       flash.enabled = onoff;
       if(onoff==true) {
           Debug.Log("Flashlight turned on");
       } else {
           Debug.Log("Flashlight turned off");
       }
    }
}
