using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Radiation : MonoBehaviour
{
    public Slider me;
    public int multiplicateur = 1;
    public float soinParFrame = 0.1f;
    public float vitesse = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void soigneRadiation()
    {
        me.value = me.value - soinParFrame;
    }

    // Update is called once per frame
    void Update()
    {
        multiplicateur = GameObject.FindGameObjectsWithTag("ActiveMachine").Length +1;
        if (me.value < 100)
        {
            me.value = me.value + (float)(vitesse * multiplicateur);
        }
        if (me.value >= 100)
            Debug.Log("Vous êtes mort.");
    }
}
