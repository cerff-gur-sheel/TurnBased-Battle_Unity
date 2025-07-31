using System.Collections.Generic;
using TB_Battle.Controller;
using TB_Battle.Data;
using TB_Battle.Model.Action;
using TB_Battle.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TB_Battle.View
{
    public class CombatView 
    {
        private PartyData _playerGroup;
        private PartyData _enemyGroup;
        
        private List<ButtonOptionsDictionary> _buttonOptionsDictionary;

        private RectTransform _parent;
        private TMP_FontAsset _fontAsset;
        
        private void Start()
        {
            CombatController.Initialize(_playerGroup,_enemyGroup, CombatController.Turn.Player);
        }

        protected void ShowActionsOfHeroOnGUI(List<IAction> actions, GameObject prefab = null)
        {
            if (_buttonOptionsDictionary != null)
            {
                foreach (var option in _buttonOptionsDictionary) 
                    Object.Destroy(option.buttonObject);
                
                _buttonOptionsDictionary.Clear();
            }
            else 
                _buttonOptionsDictionary = new List<ButtonOptionsDictionary>();
            
            foreach (var action in actions)
            {
                var (obj, tmp) =
                    prefab ? CreateButton(action, _parent, prefab) : CreateButton(action, _parent, _fontAsset);
                _buttonOptionsDictionary.Add(new ButtonOptionsDictionary(obj, tmp));
            }
        }

        private static (GameObject, TextMeshProUGUI) CreateButton(
            IAction action, RectTransform parent, TMP_FontAsset fontAsset)
        {
            var buttonObject = new GameObject(
                "DynamicButton", 
                typeof(RectTransform), 
                typeof(Button), 
                typeof(Image));
            buttonObject.transform.SetParent(parent.transform, false);

            var button = buttonObject.GetComponent<Button>();
            var rt = buttonObject.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(200, 50);
            rt.anchoredPosition = Vector2.zero;

            var textObject = new GameObject(
                "Text", 
                typeof(RectTransform), 
                typeof(TextMeshProUGUI));
            textObject.transform.SetParent(buttonObject.transform, false);

            var tmpText = textObject.GetComponent<TextMeshProUGUI>();
            tmpText.text = $"{action.Name}";
            tmpText.font = fontAsset;
            tmpText.alignment = TextAlignmentOptions.Center;
            tmpText.color = Color.black;
            tmpText.raycastTarget = false;

            var textRT = textObject.GetComponent<RectTransform>();
            textRT.anchorMin = Vector2.zero;
            textRT.anchorMax = Vector2.one;
            textRT.offsetMin = Vector2.zero;
            textRT.offsetMax = Vector2.zero;

            const int value = 99;
            button.onClick.AddListener(() => SelectOption(value));
            
            return (buttonObject, tmpText);
        }

        private static (GameObject, TextMeshProUGUI) CreateButton(
            IAction action, RectTransform parent, GameObject prefab)
        {
            var buttonObject = GameObject.Instantiate(prefab, parent);
            buttonObject.name = $"Button_{action.Name}";

            var tmpText = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            if (tmpText != null)
            {
                tmpText.text = action.Name;
            }

            var button = buttonObject.GetComponent<Button>();
            if (button != null)
            {
                const int value = 99;
                button.onClick.AddListener(() => SelectOption(value));
            }

            return (buttonObject, tmpText);
        }

        
        protected static void SelectOption(int value)
        {
            Debug.Log($"Button Pressed with value: {value}");
            
        }
    }
}
// [SerializeField] private PartyData enemyGroup;
//
//
// private CombatController _controller;
//
//
// private void Start()
// {
//     _controller.Initialize(
//         playerGroup, 
//         enemyGroup, 
//         CombatController.Turn.Player);
// }
//
// public void SelectOption(MenuButtons option) => _menuSelected = option;
//
// public enum MenuButtons { Await, Defend, Attack, UseItem }
//
// private MenuButtons _menuSelected;
// [SerializeField] private List<ButtonOptionsDictionary> buttonOptions;
//
// private void ShowOptions(MenuButtons option)
// {
//     var attacks = playerGroup.entities[0].attacks;
//
//     for (var i = 0; i < buttonOptions.Count && i < attacks.Count; i++)
//     {
//         buttonOptions[i].text.text = attacks[i].attackName;
//     }
// }
//
