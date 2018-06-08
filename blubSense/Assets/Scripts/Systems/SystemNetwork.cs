using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace Assets.Scripts.Systems
{
    public class SystemNetwork : ComponentSystem
    {
        protected override void OnStartRunning()
        {
            base.OnStartRunning();
            Debug.Log("Hallo from Network System");
        }

        protected override void OnUpdate()
        {

        }
    }
}
