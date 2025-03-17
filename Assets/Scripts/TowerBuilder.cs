using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public int towerPrice = 20;
    public Transform cursor;
    public GameObject towerPrefab;
    public Color canBuildColor = Color.green;
    public Color noBuildColor = Color.red;

    private bool canBuild;
    
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            cursor.position = hit.point;
            
            canBuild = hit.transform.CompareTag("Ground") && Player.instance.Money >= towerPrice;
            
            if(canBuild) cursor.GetComponent<Renderer>().material.color = canBuildColor;
            else cursor.GetComponent<Renderer>().material.color = noBuildColor;
            
            if (Input.GetMouseButtonDown(0) && canBuild)
            {
                Instantiate(towerPrefab, cursor.position, cursor.rotation);
                Player.instance.Money -= towerPrice;
            }
        }
    }
}
