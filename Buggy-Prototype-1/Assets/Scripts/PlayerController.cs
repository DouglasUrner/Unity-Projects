using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 25;        // Meters/second
    public float turnRate = 30;     // Degrees/second

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.forward);
        transform.Rotate(Vector3.up, horizontalInput * turnRate * Time.deltaTime);
    }
}
