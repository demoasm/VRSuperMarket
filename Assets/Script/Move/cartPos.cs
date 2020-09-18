using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class cartPos : MonoBehaviour
{
    public float Z = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0f, -transform.position.y, 0f);
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z);
        gameObject.GetComponent<Rigidbody>().GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        if (transform.localPosition.z >= 0)
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (transform.localPosition.z < Z) ? transform.localPosition.z : Z);
        else
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (transform.localPosition.z > Z) ? transform.localPosition.z : Z);
    }
}
