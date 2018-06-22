using Assets.Scripts.Components;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class SystemCamera : ComponentSystem
    {
        private struct GroupCamera
        {
            public Camera Camera;
        }
        private struct GroupPlayer
        {
            Player Player;
        }
        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<GroupCamera>())
            {
                

            }
        }
    }
}