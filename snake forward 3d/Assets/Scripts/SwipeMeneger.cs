using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SwipeMeneger : MonoBehaviour
{
    public static SwipeMeneger instance;
    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return; 

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    //Debug.Log("touch");
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    //Debug.Log("motion");
                    break;
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen)
        {
            
        }
    }
}
