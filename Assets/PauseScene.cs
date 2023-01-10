using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        PlayerController.Pause = false;
    }

    // Update is called once per frame
    public void OnJump()
    {
        PlayerController.Pause = true;
        gameObject.SetActive(false);
    }
}
