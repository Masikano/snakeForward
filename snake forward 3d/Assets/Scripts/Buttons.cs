using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    GameObject player = PlayerController.instance.GetComponent<GameObject>();
    float speed = PlayerController.instance.speed;
    public void MotionLeft()
    {
        player.transform.Translate(Vector3.left * speed);
    }
    public void MotionRight()
    {
        player.transform.Translate(Vector3.right * speed);
    }
}
