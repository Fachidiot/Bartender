using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RazerPistol : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem m_particles;
    [SerializeField]
    private LayerMask m_layerMask;
    [SerializeField]
    private Transform m_shootSource;
    [SerializeField]
    private float m_distance = 10f;

    private bool m_rayActivate = false;

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
    }

    public void StartShoot()
    {
        m_particles.Play();
        m_rayActivate = true;
    }

    public void StopShoot()
    {
        m_particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        m_rayActivate = false;
    }

    private void Update()
    {
        if (m_rayActivate)
            RaycastCheck();
    }

    void RaycastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(m_shootSource.position, m_shootSource.forward, out hit, m_distance, m_layerMask);

        if (hasHit)
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
    }
}
