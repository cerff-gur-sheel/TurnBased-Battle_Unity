using System.Collections.Generic;
using TB_Battle.Data;
using TB_Battle.Model.Action;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TB_Battle.View
{
    public class PlayerCombatUI : MonoBehaviour
    {
        [SerializeField] private PartyData playerGroup;
        
        [SerializeField] private List<ButtonOptionsDictionary> buttonOptionsDictionary;
        [SerializeField] private Canvas canvas;
        [SerializeField] private TMP_FontAsset fontAsset;

        private void Start()
        {
            var attacks = playerGroup.entities[0].attacks;
            buttonOptionsDictionary = new List<ButtonOptionsDictionary>();
            // foreach (var attack in attacks)
            // {
            //     var a = new Attack(attack, playerGroup.entities[0]);
            //     var (obj, tmp) = CreateButton(attack);
            //     buttonOptionsDictionary.Add(new ButtonOptionsDictionary(obj, tmp));
            // }
        }

        private (GameObject, TextMeshProUGUI) CreateButton(IAction action)
        {
            var buttonObject = new GameObject(
                "DynamicButton", 
                typeof(RectTransform), 
                typeof(Button), 
                typeof(Image));
            buttonObject.transform.SetParent(canvas.transform, false);

            var button = buttonObject.GetComponent<Button>();
            var rt = buttonObject.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(200, 50);
            rt.anchoredPosition = Vector2.zero;

            var textObject = new GameObject("Text", typeof(RectTransform), typeof(TextMeshProUGUI));
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
            button.onClick.AddListener(() => ButtonCalled(value));
            
            return (buttonObject, tmpText);
        }

        private void ButtonCalled(int value)
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
