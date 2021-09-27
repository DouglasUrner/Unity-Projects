using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 25;
    public float turnRate = 15;
    public bool playerControlled = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput, horizontalInput;

        if (playerControlled)
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
        }
        else
        {
            // Ignore user inputs & disable turning if not playerControlled.
            verticalInput = 1;
            horizontalInput = 0;
        }

        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        transform.Rotate(Vector3.up, horizontalInput * turnRate * Time.deltaTime);
    }
}
