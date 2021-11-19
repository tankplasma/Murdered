using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverJoin : XRBaseInteractable
{

    private bool mIsGrabed;

    private Transform mHandPosition;

    private Vector3 LookTo;

    private Vector2 leverRotation;

    private float xPos;

    [SerializeField]
    private float speed;

    private void Start()
    {
        leverRotation = new Vector2(gameObject.transform.localEulerAngles.y, gameObject.transform.localEulerAngles.z);
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        mIsGrabed = true;
        mHandPosition = interactor.transform;
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        mIsGrabed = false;
        mHandPosition = null;
    }

    private void Update()
    {
        if (mIsGrabed)
        {
            FollowHand();
            UpdatePosition();
        }
        if (!mIsGrabed)
        {
            RotateTo();
        }

    }

    private void FollowHand()
    {
        transform.LookAt(mHandPosition, LookTo);
        xPos = gameObject.transform.localEulerAngles.x;
    }

    private void UpdatePosition()
    {

        //SetLimits
        if (xPos > 70 && xPos < 290)
        {
            xPos = 70;
        }
        else if (xPos < 290 && xPos > 70)
        {
            xPos = 290;
        }
        gameObject.transform.localEulerAngles = new Vector3(xPos, leverRotation.x, leverRotation.y);
    }

    private void RotateTo()
    {
        //rotate to final position
        if (xPos < 70 && xPos > 30)
        {
            gameObject.transform.Rotate(Vector3.right * speed * Time.deltaTime);
        }
        if (xPos > 290 && xPos < 330)
        {
            gameObject.transform.Rotate(Vector3.left * speed * Time.deltaTime);
        }
        xPos = gameObject.transform.localEulerAngles.x;
    }
}

