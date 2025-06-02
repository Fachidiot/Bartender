using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonPush : MonoBehaviour
{
    [SerializeField]
    private Animator m_animator;
    [SerializeField]
    private string m_boolName = "Open";

    void Start()
    {
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>().selectEntered.AddListener(x => Toggle());
    }

    private void Toggle()
    {
        bool isOpen = m_animator.GetBool(m_boolName);
        m_animator.SetBool(m_boolName, !isOpen);
    }
}
