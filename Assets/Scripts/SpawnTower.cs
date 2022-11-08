using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class SpawnTower : MonoBehaviour,IDataPersistence
{
    // Start is called before the first frame update
    [SerializeField]
    private string id;

    [ContextMenu("Genarat guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public List<Vector2> towerPos = new List<Vector2>();
    public List<TowerEnum> towerEnums;
    public SpriteRenderer testSprite;
    public List<GameObject> towersPrefabs;
    public Transform spawnTowerRoot;
    public List<Image> towersUI;
    int spawnID = -1;
    [SerializeField]
    private int price;
    [SerializeField]
    private Text priceTxt;
    public Tilemap spawnTilemap;
    [SerializeField]
    public int priceCung;
    [SerializeField]
    public int priceLua;
    [SerializeField]
    public int priceLight;

    public int payPrice = 0;

    public TowerButton ActiveTowerButton
    {
        get;
        private set;
    }

    void Update()
    {
        if(CanSpawn())
            DetectSpawnPoint();
     

    }
    void Start()
    {
        Debug.Log("Startttttttttttttttt");
        
    }
    bool CanSpawn()
    {
        if(spawnID == -1)
            return false;
        else
            return true;    
    }

    public TowerListData towerListData;

    private void OnApplicationQuit()
    {
        towerListData = new TowerListData();
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
            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                SpawnTowers(cellPosCentered);
               // testSprite.transform.position = cellPosCentered;
                spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                Vector2 v = new Vector2();
                v.x = cellPosCentered.x;
                v.y = cellPosCentered.y;
                 testSprite.enabled = true;
                Debug.Log("======================================");
                Debug.Log("Tower: x" + cellPosCentered.x.ToString() + "|y" + cellPosCentered.y.ToString() + "z" + cellPosCentered.z.ToString());
                Debug.Log("======================================");
                towerPos.Add(v);
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
        if (GameManager.Instance.Currency >= payPrice)
        {
            GameManager.Instance.Currency -= payPrice;
            GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
            Debug.Log("towersPrefabs[id]: " + towersPrefabs[spawnID].ToString());
            tower.transform.position = position;
            TowerEnum t = new TowerEnum(position, spawnID.ToString());
            this.towerEnums.Add(t);
            Debug.Log("towerEnums: " + this.towerEnums.Count);
        }
        DeselectTower();
    }
    public void SelectTower(int id)
    {
        DeselectTower();
        switch(id) {
            case 0 : payPrice = priceCung; break;
            case 1 : payPrice = priceLua ; break;
            case 2 : payPrice = priceLight; break;

        }
       
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

    public void LoadData(GameData data)
    {
        
        if (data.TowerList!= null && data.TowerList.Count > 0)
        {
            this.towerEnums = data.TowerList;
            foreach (TowerEnum t in data.TowerList)
            {
                GameObject tower = Instantiate(towersPrefabs[int.Parse(t.id)], spawnTowerRoot);
                tower.transform.position = t.position;
            }
        }
        else
        {
            this.towerEnums = new List<TowerEnum>();
        }
    }

    public void SaveData(ref GameData data)
    {
        
        Debug.Log(this.towerEnums.Count);
        foreach (TowerEnum t in this.towerEnums)
        {
            Debug.Log("x: " + t.position.x + " | y: " + t.position.y);
            Debug.Log("ID: " + t.id);
        }
        data.TowerList = this.towerEnums;
        
        Debug.Log("Saved Towers.");
    }
}
