using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{

    public GameObject Monster;
    public GameObject Monster2;
    private int ways=1;
    private int count = 0;
    private WaitForSeconds wait2 = new WaitForSeconds(2);
    private WaitForSeconds wait10 = new WaitForSeconds(10);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(logEverySecond());

    }

    IEnumerator logEverySecond()
    {
        while (true)
        {

            if (count <= 10 && ways%2==0)
            {
                count++;
                Vector2 spawnPosition = new Vector2(0, 0);
                Instantiate(Monster, spawnPosition, Quaternion.identity);
                yield return wait2;
            }else if (count <= 10 && ways % 2 == 1)
            {
                count++;
                Vector2 spawnPosition = new Vector2(0, 0);
                Instantiate(Monster2, spawnPosition, Quaternion.identity);
                yield return wait2;
            }
            else
            {
                count = 0;
                ways++;
                yield return wait10;
            }
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
