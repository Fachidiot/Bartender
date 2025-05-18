using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabbingHandModel : MonoBehaviour
{
    // Grab �̺�Ʈ�� �� �����°� �ʿ��� �𵨿� ����.
    [SerializeField]
    private GameObject m_leftHandModel;
    [SerializeField]
    private GameObject m_rightHandModel;

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    private void HideGrabbingHand(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.tag == "Left Hand")
        {
            m_leftHandModel.SetActive(false);
        }
        else if (args.interactorObject.transform.tag == "Right Hand")
        {
            m_rightHandModel.SetActive(false);
        }
    }

    private void ShowGrabbingHand(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.tag == "Left Hand")
            m_leftHandModel.SetActive(true);
        else if (args.interactorObject.transform.tag == "Right Hand")
            m_rightHandModel.SetActive(true);
    }
}
