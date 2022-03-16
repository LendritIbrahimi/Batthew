using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectActivator : MonoBehaviour
{

    private GameObject[] effParticleSystem;

    void Start()
    {
        effParticleSystem = ApplicationManager.allEffects;
        if (effParticleSystem != null)
        {
            if (PlayerPrefs.GetInt("effectNumber", 0) != 0 && effParticleSystem != null)
            {
                Instantiate(effParticleSystem[PlayerPrefs.GetInt("effectNumber", 0) - 1], transform.parent);
            }
            if (PlayerPrefs.GetInt("characterNumber", 100) <= effParticleSystem.Length && effParticleSystem != null)
            {
                Instantiate(effParticleSystem[PlayerPrefs.GetInt("characterNumber", 100) - 1], transform.parent);
            }
        }

    }

}
