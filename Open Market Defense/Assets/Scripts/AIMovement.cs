using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform enemy;
    Vector3 direction;
    Vector3 target = new Vector3(211.8262f, 0f, 161.6237f);
    int lives;
    float directionDistance = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name != "soldier") {
            StartCoroutine(move());
            foreach (Transform childTransform in this.transform)
            {
                MeshRenderer mymesh = childTransform.GetComponent<MeshRenderer>();
                mymesh.enabled = true;
            }
        }
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        directionDistance = distance_calculator(this.transform.position, target);
        direction = vector_difference(new Vector3(this.transform.position.x, 0, this.transform.position.z), target);
        if (lives <= 0) {
            Destroy(this.gameObject);
        }
    }
    IEnumerator move()
    {
        while (true) {    
            Debug.Log(directionDistance);   
            rb.AddForce(direction * 18f);
            if (target == new Vector3(211.8262f, 0f, 161.6237f) && directionDistance <= 20f) {   
                rb.AddForce(direction * -10 * 25f);
                target = enemy.transform.position;
            }
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
        return Mathf.Sqrt(Mathf.Pow(distance.x, 2) + Mathf.Pow(distance.y, 2) + Mathf.Pow(distance.z, 2));
    }
}
