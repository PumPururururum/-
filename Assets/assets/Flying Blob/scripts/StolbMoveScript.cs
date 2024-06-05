using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolbMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;

    private UIManager2 UIManager;

    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager2>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) 
        {
            Debug.Log("Stolb Umer");
            Destroy(gameObject);
        }
        if (UIManager.FlyingBlob == false)
        {
            Debug.Log("Stolb Umer");
            Destroy(gameObject);
        }
    }
}
