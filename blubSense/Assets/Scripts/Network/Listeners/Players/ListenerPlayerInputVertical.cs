using System.Collections;
using System.Collections.Generic;
using Colyseus;
using UnityEngine;

namespace Assets.Scripts.Network.Listeners
{
    public class ListenerPlayerInputVertical : MonoBehaviour, IRoomListener
    {
        public void OnChange(DataChange obj)
        {
            Debug.Log("vertical Change");
        }
    }
}
