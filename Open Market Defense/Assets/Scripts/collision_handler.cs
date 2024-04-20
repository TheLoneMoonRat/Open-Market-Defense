using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_handler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "soldier" || collision.gameObject.name == "Terrain_0_0_1a46ecbd-1a41-4efb-98ab-bc5547954b02") {
            Destroy(this.gameObject);
        }
    }
}
