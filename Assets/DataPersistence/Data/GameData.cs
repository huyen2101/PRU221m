using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int lives;
    public int currency;
    //public TowerListData TowerListData;
    public List<TowerEnum> TowerList;
    public int waveEnemy;
    public int numberOfMonster;

    public GameData()
    {
        this.lives = 10;
        this.currency = 100;
        //TowerListData = new TowerListData();
        //TowerListData.TowerList = new List<TowerEnum>();
        TowerList = new List<TowerEnum>();
        waveEnemy = 1;
        numberOfMonster = 5;
    }
}
