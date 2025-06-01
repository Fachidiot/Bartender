using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class DisableGrabbingHandModel : MonoBehaviour
{
    // Grab 이벤트시 손 가리는게 필요한 모델에 적용.
    private GameObject m_leftHandModel;
    private GameObject m_rightHandModel;

    void Start()
    {
        m_leftHandModel = PlayerManager.Instance.GetLeftHandModel();
        m_rightHandModel = PlayerManager.Instance.GetRightHandModel();

        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    private void HideGrabbingHand(SelectEnterEventArgs args)
    {
        if (m_leftHandModel == null)
            return;

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
        if (m_rightHandModel == null)
            return;

        if (args.interactorObject.transform.tag == "Left Hand")
            m_leftHandModel.SetActive(true);
        else if (args.interactorObject.transform.tag == "Right Hand")
            m_rightHandModel.SetActive(true);
    }
}
