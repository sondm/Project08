using UnityEngine;
using TMPro;

namespace Points
{
    public class ControlScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textScoreOnScreen; // очки для отображения на экране
        private int _score;

        public void AddPoints(int scoreToAdd)
        {
            _score += scoreToAdd;
            RefreshTextOnScreen();
        }

        public void OnStartInitialized()
        {
            _score = 0;
            RefreshTextOnScreen();
        }

        /// <summary>
        /// Обновление счетчика очков на экране
        /// </summary>
        private void RefreshTextOnScreen()
        {
            _textScoreOnScreen.text = $"Очков набрано: {_score}";
        }
    }
}
