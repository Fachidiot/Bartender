using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> breakablePieces;
    [SerializeField]
    private float m_timeToBreak = 2f;

    private float m_timer = 0;

    void Start()
    {
        foreach (var item in breakablePieces)
        {
            item.SetActive(false);
        }
    }

    public void Break()
    {
        m_timer += Time.deltaTime;

        if (m_timer > m_timeToBreak)
        {
            foreach (var item in breakablePieces)
            {
                item.SetActive(true);
                item.transform.parent = null;
            }

            gameObject.SetActive(false);
        }
    }
}
