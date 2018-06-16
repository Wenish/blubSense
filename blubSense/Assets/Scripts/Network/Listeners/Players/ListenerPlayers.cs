using Colyseus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Network.Listeners
{
    public class ListenerPlayers : IRoomListener
    {
        public void OnChange(DataChange obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            var jsonObj = JToken.Parse(jsonString);

            var operation = jsonObj["operation"].ToString();
            if (operation == "add")
            {
                var playerId = jsonObj["value"]["id"].ToString();
                var positionX = jsonObj["value"]["position"]["x"].ToString();

                Debug.Log($"Player added: {playerId}");
            }
        }

        private void OperationAdd()
        {

        }

        private void OperationReplace()
        {

        }

        private void OperationRemove()
        {

        }
    } 
}
