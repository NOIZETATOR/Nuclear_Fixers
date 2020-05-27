using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorShower : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject myPict;
    private Slider meSlide;
    public float seuil = 75f;
    void Start()
    {
        myPict = gameObject.transform.GetChild(0).gameObject; 
        meSlide = gameObject.GetComponent<Slider>();
        myPict.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (meSlide.value >= meSlide.maxValue * seuil / 100 && !myPict.activeSelf)
            myPict.SetActive(true);
        else
            myPict.SetActive(false);
    }
}
