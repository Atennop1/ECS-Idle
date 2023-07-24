using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Learning.Miners
{
    public sealed class MinerView : MonoBehaviour, IMinerView
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private TMP_Text _miningPerTimeAmountText;
        
        public void Display(Miner miner)
        {
            _nameText.text = $"{miner.Name}, Уровень {miner.Level}";
            _progressSlider.value = miner.PassedTime / miner.TimeBetweenMining;
            _miningPerTimeAmountText.text = miner.MiningPerTimeAmount.ToString();
        }
    }
}