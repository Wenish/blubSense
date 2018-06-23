using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class SystemCameraMovement : ComponentSystem
    {
        private struct Group
        {
            public Camera Camera;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Group>())
            {


            }
        }
    }
}