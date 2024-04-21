using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonAim : MonoBehaviour
{
    public Transform enemyTR;
    public float force;
    public GameObject cannonball;
    public GameObject laser_pointer;
    Vector3 cannonball_direction;

    Vector3 cannonHead;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fire());
        cannonHead = this.transform.position + new Vector3(0f, 5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator fire()
    {
        while (true) {
            GameObject myball = Instantiate(cannonball, cannonHead, Quaternion.identity);
            MeshRenderer mymesh = myball.GetComponent<MeshRenderer>();
            Rigidbody myrigid = myball.GetComponent<Rigidbody>();

            mymesh.enabled = true;
            collision_handler script = myball.GetComponent<collision_handler>();
            script.get_game_parent(cannonHead);
            myrigid.AddForce(lock_target(enemyTR) * force);
            yield return new WaitForSeconds(3f);
        }
            // myball.AddForce(new Vector3(enemyTR.transform.position.x - transform.position.x, enemyTR.transform.position.y - transform.position.y, enemyTR.transform.position.z - transform.position.z));
    }

    Vector3 vector_difference(Vector3 subtractor, Vector3 subtractee) {
        Vector3 result = new Vector3(subtractee.x - subtractor.x, subtractee.y - subtractor.y, subtractee.z - subtractor.z);
        return result;
    }
    float distance_calculator(Vector3 subtractor, Vector3 subtractee) {
        Vector3 distance = vector_difference(subtractor, subtractee);
        return Mathf.Sqrt(Mathf.Pow(distance.x, 2) + Mathf.Pow(distance.y, 2) + Mathf.Pow(distance.z, 2));
    }

    Vector3 lock_target(Transform spawner) {
        float smallest_distance = 1000000f;
        Vector3 smallest_vector = new Vector3(0f, 0f, 0f);
        if (spawner.childCount > 0) {
            foreach (Transform childTransform in spawner)
            {
                float current_distance = distance_calculator(cannonHead, childTransform.position);
                if (current_distance < smallest_distance) {
                    smallest_distance = current_distance; 
                    smallest_vector = vector_difference(cannonHead, childTransform.position);
                }
            }
            StartCoroutine(create_laser(smallest_vector, smallest_distance));
        }
        return smallest_vector * (1 / smallest_distance);
    }

    IEnumerator create_laser(Vector3 direction, float distance) {
        for (int i = 0; i < distance / 2; i++) {
            GameObject laser = Instantiate(laser_pointer, (cannonHead + direction * (i / distance) * 2), Quaternion.identity);
            MeshRenderer this_mesh = laser.GetComponent<MeshRenderer>();
            // laser.transform.parent = laser_pointer.transform;
            this_mesh.enabled = true;
            yield return new WaitForSeconds(0.0005f);
        }
    }
}
