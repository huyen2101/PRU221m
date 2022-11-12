using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnMonster : MonoBehaviour,IDataPersistence
{
    private static SpawnMonster instance;

    public static SpawnMonster Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SpawnMonster>();
            }

            return instance;
        }
    }

    public GameObject Monster;
    public GameObject Monster2;
    private DataPersistenceManager dataPersistenceManager;
    [SerializeField]
    private int ways = 0;
    private int count = 0;
    private int monterInWay = 5;
    [SerializeField]
    public int dieMonster;
    private WaitForSeconds wait2 = new WaitForSeconds(2);
    private WaitForSeconds wait10 = new WaitForSeconds(10);
    // Start is called before the first frame update
    void Start()
    {
        dieMonster = 0;
        dataPersistenceManager = new DataPersistenceManager();
        
        StartCoroutine(logEverySecond());

    }

    IEnumerator logEverySecond()
    {
        
        while (true)
        {

            if (count <= monterInWay && ways%2==0)
            {
                
                    count++;
                    Vector2 spawnPosition = new Vector2(0, 0);
                /*Instantiate(Monster, spawnPosition, Quaternion.identity);*/
                ObjectPool.Instance.SpawnFromPool("Knight", spawnPosition, Quaternion.identity);
                    yield return wait2;
                
               
            }else if (count <= monterInWay && ways % 2 == 1)
            {
                
                    count++;
                    Vector2 spawnPosition = new Vector2(0, 0);
                /*Instantiate(Monster2, spawnPosition, Quaternion.identity);*/
                ObjectPool.Instance.SpawnFromPool("KnightUp", spawnPosition, Quaternion.identity);
                    yield return wait2;
               
            }
            else 
            {
                DataPersistenceManager.instance.SaveGame();
                dieMonster = 0;
                count = 0;
                ways++;
                Debug.Log(ways);
                monterInWay = monterInWay+ways;
                yield return wait10;
            }
        }




        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Ways:" + ways);
        Debug.Log("NumberOfMonster:" + monterInWay);
        Debug.Log("DieMonster:" + dieMonster);

    }

    public void LoadData(GameData data)
    {
        if (data != null)
        {
            if (data.waveEnemy > 0)
            {
                Debug.Log("Loading Saved wave: " + data.waveEnemy);
                this.ways = data.waveEnemy;
                setMonsterNumber(data.waveEnemy);
                return;
            }
        }
        this.ways = 1;
    }

    public void setMonsterNumber(int ways)
    {
        if(ways ==0) return;
        int monsterNumber = this.monterInWay;
        for(int i = 1; i<= ways; i++)
        {
            monsterNumber += i;
        }
        this.monterInWay = monsterNumber;
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("On SaveData ways: "+this.ways);
        if(this.ways %2 == 0)
        {
            data.waveEnemy = this.ways;
        }
        else if(this.ways > 0)
        {
            data.waveEnemy = this.ways - 1;
        }
        else
        {
            data.waveEnemy = 0;
        }
        
    }
}
