using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TB_Battle.Controller;
using TB_Battle.Data;
using TB_Battle.Model.Action;
using TB_Battle.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace TB_Battle.View
{
    public class CombatView 
    {
        private List<ButtonOptionsDictionary> _buttonOptionsDictionary;
        
        protected enum MenuOptions
        {
            Await,
            Defend,
            Attack,
            UseItem
        };

        private static MenuOptions _menuOption;
        protected void Start(PartyData playerGroup, PartyData enemyGroup)
        {
            CombatController.Initialize(playerGroup,enemyGroup, CombatController.Turn.Player);
        }

        protected void ShowActionsOfHeroOnGUI(
            MenuOptions menuOption, 
            List<IAction> actions, 
            RectTransform parent, 
            TMP_FontAsset fontAsset, 
            GameObject prefab = null)
        {
            _menuOption = menuOption;
            
            if (_buttonOptionsDictionary != null)
            {
                foreach (var buttonOption in _buttonOptionsDictionary) 
                    Object.Destroy(buttonOption.buttonObject);
                
                _buttonOptionsDictionary.Clear();
            }
            else 
                _buttonOptionsDictionary = new List<ButtonOptionsDictionary>();
            
            foreach (var action in actions)
            {
                var (obj, tmp) =
                    prefab ? CreateButton(action, parent, prefab) : CreateButton(action, parent, fontAsset);
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
            button.onClick.AddListener(() => SelectAction(value));
            
            return (buttonObject, tmpText);
        }

        private static (GameObject, TextMeshProUGUI) CreateButton(
            IAction action, RectTransform parent, GameObject prefab)
        {
            var buttonObject = Object.Instantiate(prefab, parent);
            buttonObject.name = $"Button_{action.Name}";

            var tmpText = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            if (tmpText != null)
            {
                tmpText.text = action.Name;
            }

            var button = buttonObject.GetComponent<Button>();
            if (button == null) return (buttonObject, tmpText);
            const int value = 99;
            button.onClick.AddListener(() => SelectAction(value));

            return (buttonObject, tmpText);
        }
        
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        protected static void SelectAction(int value)
        {
            Debug.Log($"Button Pressed with value: {value}");
            switch (_menuOption)
            {
                case MenuOptions.Await:
                    break;
                case MenuOptions.Defend:
                    break;
                case MenuOptions.Attack:
                    break;
                case MenuOptions.UseItem:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
