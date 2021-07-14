/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;


/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */

public class SampleMessageListener : MonoBehaviour
{
    // Adjust the speed for the application.
    public int rotEnc;

    private GameObject targ;
    private Transform camTarget;


    void Start()
    {
        targ = GameObject.Find("pos0");
        Transform transformTarget = targ.transform;
    }

    void Update()
    {
        //-----------------Debug without plant-------------------
       /* if (Input.GetMouseButtonUp(0))
        {
            rotEnc += 1;
            if (rotEnc > 23)
            {
                rotEnc = 0;
            }
            targ = GameObject.Find("pos" + rotEnc.ToString());
        }
        if (Input.GetMouseButtonUp(1))
        {
            rotEnc -= 1;
            if (rotEnc < 0)
            {
                rotEnc = 23;
            }
            targ = GameObject.Find("pos" + rotEnc.ToString());
        }*/
    
        //--------------------------------------------------

        Debug.Log("Rotary Encoder: " + targ);

        Transform transformTarget = targ.transform;
        moveCam(transformTarget);
    }

    void moveCam(Transform camTarget)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, camTarget.rotation, 10);
        transform.position = Vector3.MoveTowards(transform.position, camTarget.position, 10);
    }

   

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);
        int.TryParse(msg, out rotEnc);

        int rotMap = rotEnc -= 1;
        targ = GameObject.Find("pos" + rotMap.ToString());
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}