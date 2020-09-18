using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashoutControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        var name = collision.collider.name;
        Debug.Log("Name is " + name);
        transform.eulerAngles = new Vector3(0f, -90.0f, 0f);
    }
    void OnCollisionExit(Collision collision)
    {
        transform.eulerAngles = new Vector3(0f, 0.0f, 0f);
    }
}
