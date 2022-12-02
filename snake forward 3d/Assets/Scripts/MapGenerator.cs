using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{ 
    public List<GameObject> prefabMaps = new List<GameObject>();
    public List<GameObject> maps = new List<GameObject>();
    public List<GameObject> activeMaps = new List<GameObject>();
    public int mapSize = 15;

    public static MapGenerator instance;

    private void Awake()
    {
        instance = this;

        // Vector3 pos = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            foreach (GameObject map in prefabMaps)
            {
                //Debug.Log("addMap");

                //pos += Vector3.forward * mapSize;
                maps.Add(MakeMap1(map));

            }
        }
        

        foreach (GameObject map in maps)
        {

            //Debug.Log("setParent");
            map.SetActive(false);
        }
        //for (int i = 0; i < RoadGenerator.instance.maxRoadCount; i++)
        //{
        //    Debug.Log("addActiveMap" + i);
        //    AddActiveMap();

        //}
        
        //AddActiveMap();
        //AddActiveMap();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        if (RoadGenerator.instance.speed == 0) return;

        foreach(GameObject map in activeMaps)
        {
            map.transform.position -= new Vector3(0, 0, RoadGenerator.instance.speed * Time.deltaTime);
           

        }

        if (activeMaps[0].transform.position.z < -15)
        {
            RemoveFirstActiveMap();
            AddActiveMap();

        }
    }
    public void ResetMaps()
    {
        while(activeMaps.Count > 0)
        {
            RemoveFirstActiveMap();
        }
        for (int i = 0; i < RoadGenerator.instance.maxRoadCount; i++)
        {
            //Debug.Log("addActiveMap" + i);
            AddActiveMap();

        }
        //Debug.Log("AddActiveMap");
    }
    void RemoveFirstActiveMap()
    {
        activeMaps[0].SetActive(false);
        maps.Add(activeMaps[0]);
        activeMaps.RemoveAt(0);
        //Debug.Log("removeMap");
    }

    void AddActiveMap()
    {
        int r = (int)Random.Range(0, maps.Count - 1);
        GameObject go = maps[r];
        //Debug.Log("r " + r);
        go.SetActive(true);
        ActivateÑhildren(go.transform);
        
        go.transform.position = activeMaps.Count > 0 ?
            activeMaps[activeMaps.Count - 1].transform.position + Vector3.forward * mapSize :
            new Vector3(0, 0, 20);
        maps.RemoveAt(r);
        activeMaps.Add(go);

    }

    private void ActivateÑhildren(Transform parent)
    {
        
        foreach(Transform child in parent) // ìû çäåñü óáðàëè .transform ó parent
        {
            ActivateÑhildren(child);
            child.gameObject.SetActive(true);
        }        
        
    }

    GameObject MakeMap1(GameObject prefabMap)
    {
       //GameObject myMap = new GameObject();
        
            GameObject myMap = Instantiate(prefabMap, Vector3.zero, Quaternion.identity) as GameObject;
            
            myMap.transform.SetParent(transform);
        //Debug.Log("makeMap");
        return myMap;
    }
}
