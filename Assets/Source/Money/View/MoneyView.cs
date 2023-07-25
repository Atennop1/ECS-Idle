using TMPro;
using UnityEngine;

namespace Learning.Money
{
    public sealed class MoneyView : MonoBehaviour, IMoneyView
    {
        [SerializeField] private TMP_Text _valueText;

        public void Display(int score) 
            => _valueText.text = $"Money: {score.ToString()}";
    }
}