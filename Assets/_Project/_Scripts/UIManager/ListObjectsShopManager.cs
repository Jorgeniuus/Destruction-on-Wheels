using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DW.UI
{
    public class ListObjectsShopManager : MonoBehaviour
    {
        public static Action<List<GameObject>> OnFillOutList;

        [SerializeField] private List<GameObject> contentReceived;

        private void OnEnable()
        {
            OnFillOutList += FillOutListObjects;
        }
        private void OnDisable()
        {
            OnFillOutList -= FillOutListObjects;
        }
        public void FillOutListObjects(List<GameObject> content)
        {
            CleanList();

            foreach(GameObject newContent in content)
            {
                contentReceived.Add(newContent);
            }
        }

        private void CleanList()
        {
            foreach(GameObject content in contentReceived)
            {
                Destroy(content);
            }

            contentReceived.Clear();
        }
    }
}