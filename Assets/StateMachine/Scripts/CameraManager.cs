using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static Action<int> onCameraChanged; 
    
    [SerializeField] private List<GameObject> cameraList = new List<GameObject>();

    private void OnEnable()
    {
        HandleChangeCamera(0);
        onCameraChanged += HandleChangeCamera;
    }

    private void OnDisable()
    {
        onCameraChanged -= HandleChangeCamera;
    }

    private void HandleChangeCamera(int obj)
    {
        for (int i = 0; i < cameraList.Count; i++)
        {
            if(obj == i)
                cameraList[i].gameObject.SetActive(true);
            else
                cameraList[i].gameObject.SetActive(false);
        }
    }
}
