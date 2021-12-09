/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using UnityEngine.UI;
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

    public GameObject ArduinoRead;
    public Text state;


    void Start()
    {
        targ = GameObject.Find("pos0");
        Transform transformTarget = targ.transform;
    }

    void Update()
    {
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
            gotConection();
        else
            failedConnection();
    }

    public void gotConection()
    {
        Debug.Log("Connection established");
        state.text = "Connection established";
        state.color = Color.green;
    }

    public void failedConnection()
    {
        Debug.Log("Connection attempt failed or disconnection detected");
        state.text = "Connection attempt failed";
        state.color = Color.red;
        ArduinoRead.SetActive(false);
    }

    public void disconnected()
    {
        Debug.Log("disconnected");
        state.text = "Disconnected";
        state.color = Color.red;
        ArduinoRead.SetActive(false);
    }

}