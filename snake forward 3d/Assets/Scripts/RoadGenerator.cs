using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadGenerator : MonoBehaviour
{
    public static RoadGenerator instance;
    public GameObject RoadPrefab;
    private List<GameObject> roads = new List<GameObject>();
    public float startSpeed = 10;
    public float maxSpeed = 10;
    
    public float speed = 0;
    public float plusSpeed = 0.0005f;

    public float multSpeed = 0.0001f;
    public bool hardMode = true;

    public int hardStartSpeed;
    public int hardMaxSpeed;
    public float hardPlusSpeed = 0.005f;

    //public Text scoreValue;

    public int maxRoadCount = 5;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ResetLevel();
       
        //StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed == 0) return;

        foreach (GameObject road in roads)
        {
            road.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
        if (roads[0].transform.position.z < - 15)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);

            CreateNextRoad();
        }
        
        
            speed += plusSpeed;
        
        //else
        //{
        //    speed *= 1 + multSpeed;
        //}
    }

    public void StartLevel()
    {
        
        SwipeMeneger.instance.enabled = true;
        hardMode = UIManager.instance.hardModeToggle.isOn;
        if (hardMode)
        {
            startSpeed = hardStartSpeed;
            maxSpeed = hardMaxSpeed;
            plusSpeed = hardPlusSpeed;
        }
        speed = startSpeed;
        //CoinController.instance.ResetCoinCounter();
        
        //scoreValue.text = "0";
    }
    public void ResetLevel()
    {
        speed = 0;
        while(roads.Count > 0)
        {
            Destroy(roads[0]); 
            roads.RemoveAt(0);
        }
        for(int i = 0; i < maxRoadCount; i++)
        {
            CreateNextRoad();
        }

        SwipeMeneger.instance.enabled = false;
        MapGenerator.instance.ResetMaps();
        UIManager.instance.EndGame();
        

    }
    private void CreateNextRoad()
    {
        Vector3 pos = Vector3.zero;
        if(roads.Count > 0)
        {
            pos = roads[roads.Count - 1].transform.position + new Vector3(0,0,15);
        }
        //вот здесь задается, какой road будет использоваться
        GameObject go = Instantiate(RoadPrefab, pos, Quaternion.identity);
        go.transform.SetParent(transform);
        roads.Add(go);
    }
}
