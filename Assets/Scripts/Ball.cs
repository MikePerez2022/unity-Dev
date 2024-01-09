using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField][Range(1, 20)][Tooltip("Force to move object.")] float force;

    public Rigidbody rb;

    private void Awake()
    {
        
    }


    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.VelocityChange);
        }
    }
}
