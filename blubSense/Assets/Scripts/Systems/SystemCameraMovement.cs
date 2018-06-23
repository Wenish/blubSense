using Assets.Scripts.Components;
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
            public Transform Transform;
            public Target Target;
            public Offset Offset;
            public SmoothSpeed SmoothSpeed;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Group>())
            {
                if (entity.Target.Value)
                {
                    Vector3 desiredPosition = entity.Target.Value.position + entity.Offset.Value;
                    Vector3 smoothedPosition = Vector3.Lerp(entity.Transform.position, desiredPosition, entity.SmoothSpeed.Value * Time.deltaTime);
                    entity.Transform.position = smoothedPosition;

                    entity.Transform.LookAt(entity.Target.Value);
                }
            }
        }
    }
}