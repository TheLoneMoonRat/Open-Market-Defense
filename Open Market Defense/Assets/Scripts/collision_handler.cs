using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_handler : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 cannon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void get_game_parent(Vector3 my_parent) {
        cannon = my_parent;
    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "soldier" || (collision.gameObject.name == "Terrain_0_0_1a46ecbd-1a41-4efb-98ab-bc5547954b02" && distance_calculator(this.transform.position, cannon) > 10)) {
            if (collision.gameObject.name == "soldier") {
                AIMovement script = collision.gameObject.GetComponent<AIMovement>();
                script.take_damage();
            }
            Destroy(this.gameObject);
        }
    }
    Vector3 vector_difference(Vector3 subtractor, Vector3 subtractee) {
        Vector3 result = new Vector3(subtractee.x - subtractor.x, subtractee.y - subtractor.y, subtractee.z - subtractor.z);
        return result;
    }
    float distance_calculator(Vector3 subtractor, Vector3 subtractee) {
        Vector3 distance = vector_difference(subtractor, subtractee);
        return Mathf.Pow((Mathf.Pow(distance.x, 2) + Mathf.Pow(distance.y, 2) + Mathf.Pow(distance.z, 2)), 2);
    }
}
