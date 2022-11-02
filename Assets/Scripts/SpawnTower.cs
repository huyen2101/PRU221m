using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class SpawnTower : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer testSprite;
    public List<GameObject> towersPrefabs;
    public Transform spawnTowerRoot;
    public List<Image> towersUI;
    int spawnID = -1;

    public Tilemap spawnTilemap;

     void Update()
    {
        if(CanSpawn())
            DetectSpawnPoint();
     

    }

    bool CanSpawn()
    {
        if(spawnID == -1)
            return false;
        else
            return true;    
    }

    void DetectSpawnPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
           // Debug.Log(cellPosRaw);
           // testSprite.transform.position = cellPosDefault;
           if(spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                SpawnTowers(cellPosCentered);
               // testSprite.transform.position = cellPosCentered;
                spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
               // testSprite.enabled = true;
            }
            //else
            //{
            //    testSprite.enabled = false;
            //    spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.Sprite);
            //}    
        }

    }

    void SpawnTowers(Vector3 position)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID],spawnTowerRoot);
        tower.transform.position = position;
        DeselectTower();
    }
    public void SelectTower(int id)
    {
        DeselectTower();
        spawnID = id;

        towersUI[spawnID].color = Color.white;
    }
    public void DeselectTower()
    {
        spawnID = -1;
        foreach(var t in towersUI)
        {
            t.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }
    
}
