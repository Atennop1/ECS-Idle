using TMPro;
using UnityEngine;

namespace Learning.Score
{
    public sealed class ScoreView : MonoBehaviour, IScoreView
    {
        [SerializeField] private TMP_Text _valueText;

        public void Display(int score) 
            => _valueText.text = $"Score: {score.ToString()}";
    }
}