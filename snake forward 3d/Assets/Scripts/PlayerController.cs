using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public Rigidbody rb;
    //public Vector2 dir;
    //private Touch _touch;
    //[SerializeField]
    //private float _speedModifier = 0.05f;
    //private Vector3 _targetPos;

    //private Transform _target;
    //private Vector3 _offset;
    //private float _distance;


    //private Vector3 _pointScreen;
    //private Vector3 _offset;

    public Vector3 screenPos;
    public Vector3 cameraPos;
    public Vector3 playerPos;
    

    public float speed = 10;

    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerPos = transform.position;
        //speedModifier = 0.01f;
        //_targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            screenPos = Input.mousePosition;
            screenPos.z = transform.position.z;
            screenPos.y = transform.position.y;
            cameraPos = Camera.main.ScreenToWorldPoint(screenPos);
            playerPos = new Vector3(cameraPos.x * speed, transform.position.y, transform.position.z);
        }
        


        //if(Input.touchCount > 0)
        //{
        //    _touch = Input.GetTouch(0);
        //    if(_touch.phase == TouchPhase.Moved)
        //    {
        //        _targetPos = new Vector3(transform.position.x + _touch.deltaPosition.x * _speedModifier, transform.position.y, transform.position.z);
        //    }
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //    Debug.Log("touch");


        //}


        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        _target = hit.transform;
        //        _offset = _target.position - hit.point;
        //        _distance = hit.distance;
        //    }

        //    //_touch = Input.GetTouch(0);
        //    //if(_touch.phase == TouchPhase.Moved)
        //    //{
        //    //    //_targetPos = new Vector3(transform.position.x + _touch.deltaPosition.x, transform.position.y, transform.position.z);
        //    //    //_targetPos = Camera.main.ScreenToWorldPoint(new Vector3(_touch.position.x, transform.position.y, transform.position.z));
        //    //}
        //}
        //if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) && _target != null)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    _target.position = ray.origin + ray.direction * _distance + _offset;
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    _target = null;
        //}
    }
    private void FixedUpdate()
    {
        if(playerPos.x < 5 && playerPos.x > -5)
        {
            transform.position = playerPos;

        }
        //if(_targetPos.x < 5 && _targetPos.x > -5)
        //    transform.position = _targetPos;


        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("mouse");
        //    Vector3 mouse = new Vector3(Input.GetAxis("Mouse X") * speed * Time.deltaTime, 0, 0);
        //    transform.Translate(mouse * speed);
        //}
    }

    //private void OnMouseDown()
    //{
    //    _pointScreen = Camera.main.WorldToScreenPoint(transform.position);
    //    _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _pointScreen.z));
    //}

    //private void OnMouseDrag()
    //{
    //    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
    //    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
    //    transform.position = new Vector3(curPosition.x, transform.position.y, transform.position.z);
    //}
    //public void MotionLeft()
    //{
    //    transform.Translate(Vector3.left * speed);
    //}
    //public void MotionRight()
    //{
    //    transform.Translate(Vector3.right * speed);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            RoadGenerator.instance.ResetLevel();
        }
    }
}
