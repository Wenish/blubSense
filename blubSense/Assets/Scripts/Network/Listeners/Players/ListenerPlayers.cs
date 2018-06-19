using Colyseus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Network.Listeners
{
    public class ListenerPlayers : MonoBehaviour, IRoomListener
    {
        public GameObject player;
        public void OnChange(DataChange obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            var jsonObj = JToken.Parse(jsonString);

            var operation = jsonObj["operation"].ToString();
            if (operation == "add")
            {
                string playerId = jsonObj["value"]["id"].ToString();
                float positionX = float.Parse(jsonObj["value"]["position"]["x"].ToString());
                float positionY = float.Parse(jsonObj["value"]["position"]["y"].ToString());
                Vector3 spawnPosition = new Vector3(positionX, positionY);
                Quaternion quaternion = new Quaternion();
                var gameObject = Instantiate(player, spawnPosition, quaternion);

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
