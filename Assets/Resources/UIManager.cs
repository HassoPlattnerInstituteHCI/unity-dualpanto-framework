﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace DualPantoFramework
{
    public class UIManager : MonoBehaviour
    {
        public InputField portInput;
        string DefaultWindowsPort = "//.//COM3";
        string DefaultMacPort = "";
        public GameObject debugValuesWindow;
        public GameObject portWindow;
        public Text currentPort;
        public Text currentRevisionID;
        public Text currentHeartbeat;
        public Text currentUpperHandle;
        public Text currentLowerHandle;
        DateTime lastHeartbeat;
        public GameObject blindPanel;
        void Start()
        {
            lastHeartbeat = DateTime.Now;
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                portInput.text = DefaultWindowsPort;
            }
            else if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer)
            {
                portInput.text = DefaultMacPort;
            }
        }
        void Update()
        {
            TimeSpan ts = (DateTime.Now - lastHeartbeat);
            currentHeartbeat.text = ((int)ts.TotalMilliseconds).ToString();
            currentHeartbeat.color = ts.TotalMilliseconds > 1000 ? Color.red : Color.green;

            if (Input.GetKey(KeyCode.LeftAlt))
            {
                blindPanel.SetActive(false);
            }
            else
            {
                blindPanel.SetActive(true);
            }
        }
        public void ShowDebugValuesWindow()
        {
            debugValuesWindow.SetActive(true);
        }
        public void ShowPortWindow(bool shouldShow)
        {
            portWindow.SetActive(shouldShow);
        }
        public void UpdateValues(double[] values)
        {
            double rawMePosX = values[0];
            double rawMePosY = values[1];
            double rawMeRot = values[2];
            double rawItPosX = values[5];
            double rawItPosY = values[6];
            double rawItRot = values[7];

            currentUpperHandle.text =
                rawMePosX.ToString("F4") +
                " @ " +
                rawMePosY.ToString("F4") +
                "; r: " +
                rawMeRot.ToString("F4");

            currentLowerHandle.text =
                rawItPosX.ToString("F4") +
                " @ " +
                rawItPosY.ToString("F4") +
                "; r: " +
                rawItRot.ToString("F4");
        }
        public void UpdateHeartbeat()
        {
            lastHeartbeat = DateTime.Now;
        }
        public void UpdatePort(string port)
        {
            currentPort.text = port;
        }
        public void UpdateRevisionID(int revisionID)
        {
            currentRevisionID.text = revisionID.ToString();
        }

        public void StartInDebugMode()
        {
            GameObject.Find("Panto").GetComponent<DualPantoSync>().StartInDebug();
        }

        public void OnSubmitPort()
        {
            GameObject.Find("Panto").GetComponent<DualPantoSync>().SetPort(portInput.text);
        }
    }
}