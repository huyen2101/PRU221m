using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Point GridPosition { get; set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Point gridPos, Vector3 worldPos, Transform parent)
    {
        this.GridPosition = GridPosition;
        transform.position = worldPos;
        transform.SetParent(parent);
        LevelManagement.Instance.Tiles.Add(gridPos, this);
    }

    private void OnMouseOver()
    {
        Debug.Log(GridPosition.X + ", " + GridPosition.Y);
    }


}
