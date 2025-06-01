using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(SphereCollider))]
public class XRSocketTagInteractor : XRSocketInteractor
{
    [SerializeField]
    private string m_targetTag;

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && interactable.transform.tag == m_targetTag;
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.transform.tag == m_targetTag;
    }
}
