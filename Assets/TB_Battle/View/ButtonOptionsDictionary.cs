using System;
using TMPro;
using UnityEngine;

namespace TB_Battle.View
{
    [Serializable]
    public class ButtonOptionsDictionary
    {
        public GameObject buttonObject;
        public TextMeshProUGUI tmpText;

        public ButtonOptionsDictionary(GameObject buttonObject, TextMeshProUGUI tmpText)
        {
            this.buttonObject = buttonObject;
            this.tmpText = tmpText;
        }

    }
}