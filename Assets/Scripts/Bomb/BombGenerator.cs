using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{

    public GameObject bombPrefab;
    void Start()
    {
        CreateBomb();

    }

    void Update()
    {
        
    }

    void CreateBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Destroy(bomb, 10f);
    }
}
