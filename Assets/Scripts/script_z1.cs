using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_z1 : MonoBehaviour
{
    Vector3 scaling;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left);
        scaling = transform.localScale;
        scaling.x += 5f;
        transform.Translate(Vector3.right);
    }
}
