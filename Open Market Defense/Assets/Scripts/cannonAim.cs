using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonAim : MonoBehaviour
{
    public Transform enemyTR;
    public GameObject cannonball;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fire());
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator fire()
    {
        for (int i = 0; i < 5; i++) {        
            GameObject myball = Instantiate(cannonball, this.transform.position, Quaternion.identity);
            MeshRenderer mymesh = myball.GetComponent<MeshRenderer>();
            Rigidbody myrigid = myball.GetComponent<Rigidbody>();

            mymesh.enabled = true;
            myrigid.AddForce(vector_difference(this.transform.position, enemyTR.position) * 50f);
            
            yield return new WaitForSeconds(1f);
        }
            // myball.AddForce(new Vector3(enemyTR.transform.position.x - transform.position.x, enemyTR.transform.position.y - transform.position.y, enemyTR.transform.position.z - transform.position.z));
    }

    Vector3 vector_difference(Vector3 subtractor, Vector3 subtractee) {
        Vector3 result = new Vector3(subtractee.x - subtractor.x, subtractee.y - subtractor.y, subtractee.z - subtractor.z);
        return result;
    }
}
