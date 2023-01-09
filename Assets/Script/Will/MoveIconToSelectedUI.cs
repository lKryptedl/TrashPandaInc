using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveIconToSelectedUI : MonoBehaviour
{
    private RectTransform thisObj;
    [SerializeField]
    private GameObject backButton, volume, SensX, SensY;
    // Start is called before the first frame update
    void Start()
    {
        thisObj = GameObject.Find("PointToSelectedUI").GetComponent<RectTransform>();
        thisObj.localPosition = new Vector3(-434, -301, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == backButton)
        {
            thisObj.localPosition = new Vector3(-434, -301, 0);
        }
        else if (EventSystem.current.currentSelectedGameObject == volume)
        {
            thisObj.localPosition = new Vector3(-460, -116, 0);
        }
        else if (EventSystem.current.currentSelectedGameObject == SensY)
        {
            thisObj.localPosition = new Vector3(-460, 48, 0);
        }
        else
        {
            thisObj.localPosition = new Vector3(-460, 243, 0);
        }
    }
}
