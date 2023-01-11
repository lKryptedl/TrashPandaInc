using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Update()
    {
        Time.timeScale = 0;
        PlayerController.Pause = false;
    }
    // Update is called once per frame
    public void OnJump()
    {
        PlayerController.Pause = true;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
