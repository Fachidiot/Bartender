using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargaritaMaker : MonoBehaviour
{

    [SerializeField]
    private GameObject level2;
    [SerializeField]
    private GameObject level3;
    [SerializeField]
    private GameObject level4;

    [SerializeField]
    private bool glassActive;
    public void GlassActive() { glassActive = true; }
    public void GlassInactive() { glassActive = false; }
    private bool liquidActive;
    public void LiquidActive() { liquidActive = true; }
    public void LiquidInactive() { liquidActive = false; }
    [SerializeField]
    private bool limeActive;
    public void LimeActive() { limeActive = true; }
    public void LimeInactive() { limeActive = false; }
    [SerializeField]
    private bool umbrellaActive;
    public void UmbrellaActive() { umbrellaActive = true; }
    public void UmbrellaInactive() { umbrellaActive = false; }


    void Start()
    {
        
    }

    void Update()
    {
        //Function1();
        Function2();
    }

    void Function1()
    {
        if (glassActive)
            level2.SetActive(true);
        else
            level2.SetActive(false);

        //if (liquidActive)
        //    level3.SetActive(true);
        //else
        //    level3.SetActive(false);

        if (limeActive && umbrellaActive)
            level4.SetActive(true);
        else
            level4.SetActive(false);
    }

    void Function2()
    {
        if (glassActive)
        {   // when glass is active. 
            level2.SetActive(true);
            level3.SetActive(true);
        }
        else
        {   // when glass is inactive.
            level2.SetActive(false);
            level3.SetActive(false);
        }

        // when margarita is complete.
        if (liquidActive && limeActive && umbrellaActive)
            level4.SetActive(true);
        else
            level4.SetActive(false);
    }

    // TODO : when margarita didnt completed. can able to end?
    void UpdateMargarita()
    {
        // TODO : margarita's liquid, lime, umbrella update
    }
}
