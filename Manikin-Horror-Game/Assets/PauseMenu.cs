using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }
    public void Pause(){
        //Inventory.instance.Player.enableCameraControl = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        Time.timeScale = 0;
        menu.SetActive(true);

    }
    public void Resume(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}
