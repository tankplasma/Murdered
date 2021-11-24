using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RayCastHand : MonoBehaviour
{

    [SerializeField]
    public XRNode device;

    private float grip;

    [SerializeField]
    private float distance;

    private int mask;

    public Transform raycastPoint;

    public GameObject ObjectSelected;

    void Start()
    {
        distance = 1f;
        mask = 1 << 9;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice input = InputDevices.GetDeviceAtXRNode(device);
        input.TryGetFeatureValue(CommonUsages.grip , out grip);

        if (grip == 1f)
        {
            RayCastHandForOject();
        }
        if (grip < 1f)
        {
            Debug.DrawRay(raycastPoint.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * distance, Color.black);
            ObjectSelected = null;
        }
    }

    private void RayCastHandForOject()
    {
        Ray ray;

        RaycastHit hit;

        ray = new Ray(raycastPoint.transform.position, gameObject.transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray, out hit, distance , mask))
        {
            Debug.DrawRay(raycastPoint.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * distance, Color.red);
            ObjectSelected = hit.collider.gameObject;
        }
        else
        {
            Debug.DrawRay(raycastPoint.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * distance, Color.yellow);
        }
    }
}
