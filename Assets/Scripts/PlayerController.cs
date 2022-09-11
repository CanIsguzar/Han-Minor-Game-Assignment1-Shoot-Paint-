using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public float rotationSpeed;

    RaycastHit hitinfo;
    public float hoverHeight = 0.7f;
    float offsetdistance;
    //public Vector2 moveVal;


    public Vector3 moveVal;

    public float movementSpeed;
    private Vector3 rotation;

    //public Transform target;

    //get OnMovie input and put it in a vector to be used later on
    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector3>();

    }

    void OnRotate(InputValue value)
    {
        rotation = new Vector3(0, value.Get<float>(), 0);
    }

    void Update()
    {
        PlayerHover();
    }

    void FixedUpdate()
    {
        transform.Rotate(rotation * rotationSpeed * Time.fixedDeltaTime, Space.Self);
        transform.Translate(moveVal * movementSpeed * Time.fixedDeltaTime);
    }

    void PlayerHover()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out hitinfo, 20f))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hitinfo.normal), hitinfo.normal);
            offsetdistance = hoverHeight - hitinfo.distance;
            transform.localPosition = new Vector3(transform.position.x, transform.position.y + offsetdistance, transform.position.z);
        }

    }


    public void Rotate(Vector3 axis, float angle, Space relativeTo = Space.Self)
    {
        player.transform.Rotate(axis, angle, relativeTo);

    }

    public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        player.transform.SetPositionAndRotation(position, rotation);
    }

}
