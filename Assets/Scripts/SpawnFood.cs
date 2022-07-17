using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnFood : MonoBehaviour
{
    public Transform topBorder, bottomBorder, leftBorder, rightBorder;
    public GameObject foodPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckFood();   
    }

    void Spawn()
    {
        int y = (int)Random.Range(bottomBorder.position.y, topBorder.position.y);
        int x = (int)Random.Range(leftBorder.position.x, rightBorder.position.x);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
           
    }

    public void CheckFood()
    {
        if (!GameObject.FindGameObjectWithTag("Food"))
        {
            Spawn();
        }        
    }
}
