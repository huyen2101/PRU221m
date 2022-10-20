using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingTower : MonoBehaviour
{
    public GameObject archerTower;

    //private bool isBuilding;

    //public GameObject placement;

    //private GameObject hoverTile;

    //public Camera cam;

    //public LayerMask mask;

    //public void Start()
    //{
    //    StartBuilding();
    //}
    //public Vector2 GetMousePosition()
    //{
    //    return cam.ScreenToWorldPoint(Input.mousePosition);  
    //}

    ////public void GetCurrentHoverTile()
    ////{
    ////    Vector2 mousePosition = GetMousePosition();

    ////    RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0, 0), 0.1f, mask, -100, 100);

    ////    if(hit.collider == null)    

    ////}

    //public void StartBuilding()
    //{
    //    isBuilding = true;
    //    placement = Instantiate(archerTower);

      
    //}

    //public void EndBuilding()
    //{
    //    isBuilding = false;
    //}


    //// Update is called once per frame
    //public void Update()
    //{
    //    Debug.Log(GetMousePosition());
    //    StartBuilding();
    //}
}
