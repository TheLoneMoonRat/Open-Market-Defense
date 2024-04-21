using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_soldiers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject soldier;
    void Start()
    {
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator spawner()
    {
        while (true) {
            GameObject new_soldier = Instantiate(soldier, this.transform.position, this.transform.rotation);
            new_soldier.transform.parent = this.transform;
            yield return new WaitForSeconds(2f);
        }
            // myball.AddForce(new Vector3(enemyTR.transform.position.x - transform.position.x, enemyTR.transform.position.y - transform.position.y, enemyTR.transform.position.z - transform.position.z));
    }
}
