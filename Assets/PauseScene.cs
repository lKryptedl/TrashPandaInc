using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        PlayerController.Pause = false;
    }

    // Update is called once per frame
    public void OnJump()
    {
        Time.timeScale = 1;
        PlayerController.Pause = true;
        gameObject.SetActive(false);
    }
}
