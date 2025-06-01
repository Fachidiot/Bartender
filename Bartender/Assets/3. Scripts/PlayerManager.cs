using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_leftHandModel;
    [SerializeField]
    private GameObject m_rightHandModel;

    public static PlayerManager Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);
        Instance = this;

        DontDestroyOnLoad(Instance);
    }

    public GameObject GetLeftHandModel()
    {
        return m_leftHandModel;
    }
    public GameObject GetRightHandModel()
    {
        return m_rightHandModel;
    }
}
