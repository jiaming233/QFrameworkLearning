using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour
    {
        void Start()
        {
            GameStartEvent.Register(OnGameStart);
        }

        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }

        void OnDestroy() 
        {
            GameStartEvent.UnRegister(OnGameStart);
        }
    }
}
