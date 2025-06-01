using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class PlayStep : MonoBehaviour
{
    PlayableDirector m_director;
    public List<Step> m_steps;

    void Start()
    {
        m_director = GetComponent<PlayableDirector>();
        m_steps = new List<Step>();
    }

    public void PlayStepIndex(int index)
    {
        Step step = m_steps[index];
        
        if (!step.hasPlayed)
        {
            step.hasPlayed = true;

            m_director.Stop();
            m_director.time = step.time;
            m_director.Play();
        }
    }
}

[Serializable]
public class Step
{
    public string name;
    public float time;
    public bool hasPlayed = false;
}