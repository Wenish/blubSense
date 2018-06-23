using Assets.Scripts.Components;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class SystemCameraTarget : ComponentSystem
    {
        private struct GroupCamera
        {
            public Camera Camera;
            public Target Target;
        }

        private struct GroupPlayer
        {
            public Transform Transform;
            public Player Player;
        }

        protected override void OnUpdate()
        {
            foreach (var camera in GetEntities<GroupCamera>())
            {
                foreach(var player in GetEntities<GroupPlayer>())
                {
                    if (player.Player.IsCurrentPlayer)
                    {
                        camera.Target.Value = player.Transform;
                    }
                }
            }
        }
    }
}
