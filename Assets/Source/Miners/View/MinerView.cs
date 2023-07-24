using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Learning.Miners
{
    public sealed class MinerView : MonoBehaviour, IMinerView
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _levelText;
        
        [Space]
        [SerializeField] private TMP_Text _miningPerTimeAmountText;
        [SerializeField] private Slider _progressSlider;

        public void Display(Miner miner)
        {
            _nameText.text = $"{miner.Name}";
            _levelText.text = $"Уровень {miner.Level}";
            
            _miningPerTimeAmountText.text = $"{miner.MiningPerTimeAmount.ToString()}/c";
            _progressSlider.value = miner.PassedTime / miner.TimeBetweenMining;
        }
    }
}