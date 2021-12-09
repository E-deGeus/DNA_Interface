using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject MenuCanvas;
    private bool toggleBool;

    void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggleBool = !toggleBool;
            MenuCanvas.SetActive(toggleBool);
            Cursor.visible = toggleBool;
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
