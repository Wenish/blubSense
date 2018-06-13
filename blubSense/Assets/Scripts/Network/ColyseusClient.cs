using Colyseus;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Network
{
    public class ColyseusClient : MonoBehaviour
    {
        public Client client;
        public Room room;

        public string serverName = "localhost";
        public string port = "8080";
        public string roomName = "match";
        IEnumerator Start()
        {
            Debug.Log("Starting ColyseusClient");
            Debug.Log($"Connecting to ws://{serverName}:{port}");
            String uri = "ws://" + serverName + ":" + port;
            client = new Client(uri);
            client.OnClose += (object sender, EventArgs e) => Debug.Log("CONNECTION CLOSED");

            yield return StartCoroutine(client.Connect());

            room = client.Join(roomName);
            room.OnReadyToConnect += (sender, e) => StartCoroutine(room.Connect());
            room.OnJoin += OnRoomJoined;
            room.OnError += (sender, e) =>
            {
                Debug.Log("oops, error ocurred:");
                Debug.Log(e);
            };

            room.Listen("scene/:id", OnSceneChange);

            //room.OnMessage += OnData;

            while (true)
            {
                client.Recv();

                yield return 0;
            }
        }

        private void OnSceneChange(DataChange obj)
        {
            Debug.Log(obj);
        }

        void OnRoomJoined(object sender, EventArgs e)
        {
            Debug.Log($"Joined {roomName} room successfully.");
        }

        void OnApplicationQuit()
        {
            // Ensure the connection with server is closed immediatelly
            room.Leave();
            client.Close();
        }

    }
}
