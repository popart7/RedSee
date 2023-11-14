using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace THC_Environment
{
    public class ActivateOnEnable : MonoBehaviour
    {

        public GameObject activate;
        public GameObject deactivate;

        private void Start()
        {
            activate.SetActive(true);
            deactivate.SetActive(false);
        }
    }
}
