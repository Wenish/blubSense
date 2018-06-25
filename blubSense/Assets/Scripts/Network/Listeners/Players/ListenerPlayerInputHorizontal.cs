using System.Collections;
using System.Collections.Generic;
using Colyseus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Assets.Scripts.Network.Listeners
{
    public class ListenerPlayerInputHorizontal : MonoBehaviour, IRoomListener
    {
        public void OnChange(DataChange obj)
        {
            Debug.Log("Horizontal Change");
            var jsonString = JsonConvert.SerializeObject(obj);
            var jsonObj = JToken.Parse(jsonString);

            var operation = jsonObj["operation"].ToString();
            if (operation == "add")
            {
                OperationAdd(jsonObj);
            }
        }
        private void OperationAdd(JToken jsonObj)
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