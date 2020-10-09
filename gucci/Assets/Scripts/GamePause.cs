using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    private static bool cursorLocked = true;
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetButtonUp("Cancel"))
            if (gamePaused == false)
            {
                Time.timeScale = 0;
                gamePaused = true;
                //Cursor.visible = true;
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
                //Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
        }
    }
}
