using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using BlubSense.Components;

public class SystemPlayerInput : ComponentSystem
{
    private struct Group
    {
        public PlayerInput PlayerInput;
    }
    protected override void OnUpdate()
    {
        foreach(var entity in GetEntities<Group>())
        {
            entity.PlayerInput.Horizontal = Input.GetAxis("Horizontal");
        }
    }
}
