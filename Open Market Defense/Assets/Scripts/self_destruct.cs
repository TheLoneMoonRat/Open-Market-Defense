using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_destruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name != "Laser_pointer") {
            StartCoroutine(death());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator death()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);    
    }
}
