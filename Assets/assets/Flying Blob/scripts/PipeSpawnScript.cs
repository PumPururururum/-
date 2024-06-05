using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject Stolb;
    public float spawnRate = 2;
    private float timer = 0;
    public float heighOffset = 10;
    //public Blolbscript blob;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
       // spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            count++;
        }
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else if (timer >= spawnRate && count != 0)
        {
            spawnPipe();
            timer = 0;
        }
        
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heighOffset;
        float highestPoint = transform.position.y + heighOffset;
        Instantiate(Stolb, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),0), transform.rotation);
    }
}
