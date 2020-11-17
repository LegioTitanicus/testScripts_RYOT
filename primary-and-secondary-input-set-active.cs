﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PanelToggle : MonoBehaviour
{

    public GameObject[] panels;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SwitchType(RightSelect, RightTeleport);
        SwitchType(LeftSelect, LeftTeleport);
    }

    void SwitchType(GameObject selector, GameObject teleporter)
    {
        XRController controller = selector.GetComponent<XRController>();
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out bool input))
        {
            if (vector2.magnitude >= 0.2f)
            {
                //print("Magnitude cutoff surpassed");
                selector.SetActive(false);
                teleporter.SetActive(true);
            }
            else
            {
                selector.SetActive(true);
                teleporter.SetActive(false);
            }
        }
    }
}