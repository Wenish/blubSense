using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;
using Assets.Scripts.Components;

namespace Assets.Scripts.Systems
{
    public class SystemPlayerMovement : ComponentSystem
    {
        private struct Group
        {
            public Transform Transform;
            public PlayerInput PlayerInput;
            public Speed Speed;
        }

        protected override void OnUpdate()
        {
            foreach(var entity in GetEntities<Group>())
            {
                var posistion = entity.Transform.position;
                var rotation = entity.Transform.rotation;

                posistion.x += entity.Speed.Value * entity.PlayerInput.Horizontal * Time.deltaTime;
                posistion.z += entity.Speed.Value * entity.PlayerInput.Vertical * Time.deltaTime;
                rotation.w = Mathf.Clamp(entity.PlayerInput.Horizontal, -0.5f, 0.5f);

                entity.Transform.position = posistion;
                entity.Transform.rotation = rotation;
            }
        }
    } 
}
