using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove : MonoBehaviour
{
    [Header("Movement")]

    [SerializeField][Range(1, 20)][Tooltip("Force to move object.")] float force;
    [SerializeField][Range(0, 5)] float speed = 5;
    [SerializeField][Range(-360, 360)] float angle;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.E)) transform.rotation *= Quaternion.AngleAxis(angle * Time.deltaTime, Vector3.up);


        if (Input.GetKey(KeyCode.W)) transform.position += transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) transform.position += transform.right * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.S)) transform.position -= transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) transform.position -= transform.right * speed * Time.deltaTime;
    }
}
