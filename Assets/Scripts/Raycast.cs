using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour

{
    RaycastHit hitinfo;
    [SerializeField] private Renderer myObject;


    void Update()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray, out hitinfo, 20f))
        {
            Debug.Log("Hit Something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
        }
        else
        {
            Debug.Log("Unpaintable");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);

        }
    }

    void OnFire()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray, out hitinfo, 20f))
        {
            Debug.DrawLine(transform.position, hitinfo.point, Color.green);
            if (!hitinfo.collider.CompareTag("Unpaintable"))
            {
                myObject = hitinfo.collider.GetComponent<Renderer>();
                myObject.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }
        }
        else
        {

            Debug.Log("Unpaintable");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);

        }
    }


}
