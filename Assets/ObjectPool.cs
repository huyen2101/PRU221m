using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class Pool
    {
        public string tag;

        public GameObject prefab;

        public int size;


    }

    public static ObjectPool Instance;

    public void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    void Start()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }



    }

    public GameObject SpawnFromPool(string tag, Vector3 postion, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("pool null");
            return null;

        }

        GameObject objToSpawn = poolDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = postion;
        objToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }

}
