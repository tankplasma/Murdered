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

    public GameObject ObjectSelected;

    void Start()
    {
        distance = 0.05f;
        mask = 1 << 0;
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
            Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.down) * distance, Color.black);
        }
    }

    private void RayCastHandForOject()
    {
        Ray ray;

        RaycastHit hit;

        ray = new Ray(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.down));

        if (Physics.Raycast(ray, out hit, distance))
        {
            Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.down) * distance, Color.red);
            ObjectSelected = hit.collider.gameObject;
        }
        else
        {
            Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.down) * distance, Color.yellow);
        }
    }
}
