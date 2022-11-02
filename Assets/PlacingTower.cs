using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingTower : MonoBehaviour
{
    public GameObject monsterPrefab;
    private GameObject monster;

    // Start is called before the first frame update

    private bool CanPlaceMonster()
    {
        return monster == null;
    }

    //1
    void OnMouseUp()
    {
        //2
        if (CanPlaceMonster())
        {
            //3
            monster = (GameObject)
              Instantiate(monsterPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            // TODO: Deduct gold
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
