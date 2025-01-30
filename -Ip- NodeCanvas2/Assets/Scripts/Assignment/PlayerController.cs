using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        rb = GetComponent<Rigidbody>();
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            rb.transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            rb.transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            rb.transform.position -= new Vector3(0, 0, speed) * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            rb.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (player.transform.localScale.x <= 1)
        {
            player.transform.localScale += new Vector3(0.2f, 0, 0.2f) * Time.deltaTime;
        }
    }
}
