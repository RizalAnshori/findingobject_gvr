using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ReticleController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private readonly int IsOpenAnimId = Animator.StringToHash("isOpen");
    private readonly int ClickAnimId = Animator.StringToHash("click");

    private void Start()
    {
        if(!animator)animator = GetComponent<Animator>();
    }

    public void OnActivate(bool isActivated)
    {
        animator.SetBool(IsOpenAnimId, isActivated);
    }

    public void OnClick()
    {
        animator.SetTrigger(ClickAnimId);
    }
}
