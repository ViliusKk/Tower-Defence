using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Upgrade",menuName = "Tower Upgrade")]

public class TowerUpgrade : ScriptableObject
{
    public int cost;
    public float cooldown;
    public GameObject towerPrefab;
    public GameObject bulletPrefab;
    public Sprite icon;
}
