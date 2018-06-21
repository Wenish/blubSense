using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Assets.Scripts.Components;

namespace Assets.Scripts.Systems
{
    public class SystemPlayerInput : ComponentSystem
    {
        private struct Group
        {
            public PlayerInput PlayerInput;
            public Player Player;
        }
        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Group>())
            {
                if (entity.Player.IsCurrentPlayer)
                {
                    entity.PlayerInput.Horizontal = Input.GetAxis("Horizontal");
                    entity.PlayerInput.Vertical = Input.GetAxis("Vertical");
                }
            }  
        }
    } 
}
