using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PanelToggle : MonoBehaviour
{

    public GameObject[] panels;
    public XRController[] controllers;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowPanels(panels, controllers);
    }

    void ShowPanels(GameObject[] panels, XRController[] controllers)
    {
        foreach (XRController controller in controllers)
        {
            XRController inputDevice = controller.GetComponent<XRController>();
            /*bool inputPrimary = false;
            bool inputSecondary = false;*/
            if (inputDevice.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool inputPrimary) || inputDevice.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool inputSecondary))
            {
                foreach (GameObject panel in panels)
                    if (inputPrimary || inputSecondary)
                    {
                        panel.SetActive(!panel.activeSelf);
                    }
            }
        }

    }
}
