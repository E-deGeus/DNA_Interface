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
    public float speed = 1.0f;
    public int rotEnc;

    public Transform position1, position2, position3, position4, position5;
    private Transform camTarget;

    void Update()
    {
        Debug.Log(rotEnc);

        if (rotEnc >= 1 && rotEnc <= 4)
        {
            moveCam(position1);
        }
        if (rotEnc >= 5 && rotEnc <= 8)
        {
            moveCam(position2);
        }
        if (rotEnc >= 9 && rotEnc <= 14)
        {
            moveCam(position3);
        }
        if (rotEnc >= 15 && rotEnc <= 18)
        {
            moveCam(position4);
        }
        if (rotEnc >= 19 && rotEnc <= 24)
        {
            moveCam(position5);
        }
    }

    void moveCam(Transform camTarget)
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, camTarget.position, speed * Time.deltaTime);
    }


    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);
        int.TryParse(msg, out rotEnc);
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