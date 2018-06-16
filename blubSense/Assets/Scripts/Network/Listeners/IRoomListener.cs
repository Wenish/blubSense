using Colyseus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Network.Listeners
{
    public interface IRoomListener
    {
        void OnChange(DataChange obj);
    } 
}
