using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    [SerializeField]
    private Transform mine;

    [SerializeField]
    private GameObject encre;

    private int mask = 1 << 10;

    private RaycastHit hit;

    private void FixedUpdate()
    {
        Ray ray;

        ray = new Ray(mine.position, gameObject.transform.TransformDirection(Vector3.down));

        Debug.DrawRay(mine.position, gameObject.transform.TransformDirection(Vector3.down) * 0.01f, Color.black);


        if (Physics.Raycast(ray, out hit, 0.03f, mask))
        {
            Debug.DrawRay(mine.position, gameObject.transform.TransformDirection(Vector3.down) * 0.01f, Color.green);

            Instantiate(encre, hit.point, hit.collider.gameObject.transform.rotation);
        }
    }
}
