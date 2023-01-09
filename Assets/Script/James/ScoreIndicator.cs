using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class ScoreIndicator : MonoBehaviour
{
    public RectTransform thisObj;
    public GameObject Restart, Menu;

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == Restart)
        {
            thisObj.localPosition = new Vector3(360, -210, 0);
        }
        else if (EventSystem.current.currentSelectedGameObject == Menu)
        {
            thisObj.localPosition = new Vector3(-350, -210, 0);
        }
    }
}
