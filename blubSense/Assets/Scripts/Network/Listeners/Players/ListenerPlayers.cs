using Assets.Scripts.Components;
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

        private ColyseusClient colyseusClient;

        void Start()
        {
            colyseusClient = GetComponent<ColyseusClient>();
        }

        public void OnChange(DataChange obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            var jsonObj = JToken.Parse(jsonString);

            var operation = jsonObj["operation"].ToString();
            if (operation == "add")
            {
                string playerId = jsonObj["value"]["id"].ToString();
                float speed = float.Parse(jsonObj["value"]["moveSpeed"].ToString());
                float positionX = float.Parse(jsonObj["value"]["position"]["x"].ToString());
                float positionY = float.Parse(jsonObj["value"]["position"]["y"].ToString());
                float positionZ = float.Parse(jsonObj["value"]["position"]["z"].ToString());
                Vector3 spawnPosition = new Vector3(positionX, positionY, positionZ);
                Quaternion quaternion = new Quaternion();
                var gameObject = Instantiate(player, spawnPosition, quaternion);

                gameObject.GetComponent<NetworkEntity>().Id = playerId;
                gameObject.GetComponent<Speed>().Value = speed;

                if (colyseusClient.client.id == playerId)
                {
                    gameObject.GetComponent<Player>().IsCurrentPlayer = true;
                }
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
