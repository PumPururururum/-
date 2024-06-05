using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScriptEasy : MonoBehaviour
{
    public LogicScript logic;
    public BlobscriptEasy blob;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        blob = GameObject.FindGameObjectWithTag("Blob").GetComponent<BlobscriptEasy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && blob.blobIsAlive == true)
        {
            logic.addScore(1);
        }
    }
}
