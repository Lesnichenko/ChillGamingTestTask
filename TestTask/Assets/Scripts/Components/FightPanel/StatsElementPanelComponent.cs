using Core.Wrappers;
using UnityEngine;
using UnityEngine.UI;

namespace Components.FightPanel
{
    public class StatsElementPanelComponent : MonoBehaviorWrapper
    {
        [SerializeField] private Image _iconStat;
        [SerializeField] private Text _valueStat;

        public void SetData(Sprite spriteStat, float valueStat)
        {
            _iconStat.sprite = spriteStat;
            SetData(valueStat);
        }

        public void SetData(float valueStat)
        {
            _valueStat.text = valueStat.ToString();
        }
    }
}