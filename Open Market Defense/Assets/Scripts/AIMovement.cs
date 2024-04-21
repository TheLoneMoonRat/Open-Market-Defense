using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform enemy;
    Vector3 target;
    int lives;
    float targetDistance;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(move());
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        target = vector_difference(new Vector3(this.transform.position.x, 0, this.transform.position.z), new Vector3(211.1f, 0, 150f));
        targetDistance = distance_calculator(this.transform.position, new Vector3(211.1f, 0, 150f));
        if (lives == 0) {
            foreach (Transform childTransform in this.transform)
            {
                MeshRenderer mymesh = childTransform.GetComponent<MeshRenderer>();
                mymesh.enabled = false;
            }
        }
    }
    IEnumerator move()
    {
        while (targetDistance != 5f) {       
            rb.AddForce(target * 2f);
            yield return new WaitForSeconds(0.5f);
        }
            // myball.AddForce(new Vector3(enemyTR.transform.position.x - transform.position.x, enemyTR.transform.position.y - transform.position.y, enemyTR.transform.position.z - transform.position.z));
    }
    public void take_damage () {
        lives --;
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
