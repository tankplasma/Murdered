using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
    private Animator animator;

    public Text screen;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void GoToStage(int stage)
    {
        screen.text = "" + stage;

        animator.SetInteger("stage", stage);
    }
}
