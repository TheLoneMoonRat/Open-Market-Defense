using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAround : MonoBehaviour
{
    public Transform mybody;
    bool z_direction_up;
    bool z_direction_down;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        z_direction_up = Input.GetKeyDown("space");
        z_direction_down = Input.GetKeyDown("left shift");
        var x_direction = Input.GetAxis("Horizontal");
        var y_direction = Input.GetAxis("Vertical");
        int z_direction = 0;
        if (z_direction_up) {
            z_direction = 2;
        } else if (z_direction_down) {
            z_direction = -2;
        } else {
            z_direction_down = false;
            z_direction_up = false;
        }
        mybody.Translate(0, z_direction, y_direction / 15);
        mybody.Rotate(0, x_direction / 15, 0);
        
    }
}
