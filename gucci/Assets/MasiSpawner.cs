using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasiSpawner : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject MasiPrefab;



    private float MasiTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        prefabList.Add(MasiPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        masiSpawnTimer();
    }

    //time interval between when the masis spawn and where are they going to spawn
    void masiSpawnTimer()
    {

        if (Time.time > MasiTime)
        {

            MasiTime += 5;
            int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count);
            Instantiate(prefabList[prefabIndex], new Vector3(1, 0, 2), Quaternion.Euler(0, 0, 0));
        }

    }
}