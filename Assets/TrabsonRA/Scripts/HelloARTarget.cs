//=============================================================================================================================
//
// Copyright (c) 2015-2018 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
// EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
// and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//=============================================================================================================================

using UnityEngine;
using System.Linq;
using EasyAR;

namespace Sample
{
    public class HelloARTarget : MonoBehaviour
    {
        private const string title = "Please enter KEY first!";
        private const string boxtitle = "===PLEASE ENTER YOUR KEY HERE===";
        private const string keyMessage = ""
            + "Steps to create the key for this sample:\n"
            + "  1. login www.easyar.com\n"
            + "  2. create app with\n"
            + "      Name: HelloARMultiTarget-MultiTracker (Unity)\n"
            + "      Bundle ID: cn.easyar.samples.unity.helloarmultitarget.mt\n"
            + "  3. find the created item in the list and show key\n"
            + "  4. replace all text in TextArea with your key";

        private void Awake()
        {
            if (FindObjectOfType<EasyARBehaviour>().Key.Contains(boxtitle))
            {
#if UNITY_EDITOR
                UnityEditor.EditorUtility.DisplayDialog(title, keyMessage, "OK");
#endif
                Debug.LogError(title + " " + keyMessage);
            }
        }

        void CreateTarget(string targetName, out SampleImageTargetBehaviour targetBehaviour)
        {
            GameObject Target = new GameObject(targetName);
            Target.transform.localPosition = Vector3.zero;
            targetBehaviour = Target.AddComponent<SampleImageTargetBehaviour>();
        }

        void Start()
        {

            ImageTrackerBehaviour tracker = null;
            foreach (var behaviour in FindObjectsOfType<ImageTrackerBehaviour>())
            {
                if (behaviour.name == "ImageTracker-3")
                    tracker = behaviour;
            }
            if (!tracker)
                return;
            tracker.SimultaneousNum = 200;
        }
    }
}

