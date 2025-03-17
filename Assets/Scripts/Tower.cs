using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public List<TowerUpgrade> upgrades;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float cooldown = 1f;
    
    public List<GameObject> enemies;

    private int currentUpgrade = 0;
    void Start()
    {
        InvokeRepeating("Fire", 0, cooldown);
    }

    void Fire()
    {
        CleanTargets();
        if (enemies.Count == 0) return;
        var target = enemies[Random.Range(0, enemies.Count)];
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().target = target.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy")) enemies.Add(other.gameObject);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Enemy")) enemies.Remove(other.gameObject);
    }

    void CleanTargets()
    {
        enemies.RemoveAll(enemy => enemy == null);
    }

    public void UpgradeTower()
    {
        if (Player.instance.Money >= upgrades[currentUpgrade].cost)
        {
            cooldown = upgrades[currentUpgrade].cooldown;
            if(upgrades[currentUpgrade].bulletPrefab != null) bulletPrefab = upgrades[currentUpgrade].bulletPrefab;
            if (upgrades[currentUpgrade].towerPrefab != null)
            {
                Instantiate(upgrades[currentUpgrade].towerPrefab, transform.position, Quaternion.identity);
            }
            
            Player.instance.Money -= upgrades[currentUpgrade].cost;
            currentUpgrade++;
        }
    }
}
