using System;
using System.Collections.Generic;
using Core.Wrappers;
using Models.Fighter;
using UnityEngine;

namespace Components.FightPanel
{
    public class StatsPanelComponent : MonoBehaviorWrapper
    {
        [SerializeField] private StatsElementPanelComponent _statsElementPrefab;
        [SerializeField] private Transform _parentStatsElement;
        
        private List<StatsElementPanelComponent> _statElements = new List<StatsElementPanelComponent>();

        public void SetData(IFighterData fighterData)
        {
            
        }

        private void SpawnStatElements(int statsCount)
        {
            if (_statElements.Count < statsCount)
            {
                while (_statElements.Count < statsCount)
                {
                    var component = Instantiate(_statsElementPrefab, _parentStatsElement);
                    _statElements.Add(component);
                }
            }

            if (_statElements.Count > statsCount)
            {
                while (_statElements.Count > statsCount)
                {
                    var statsElementPanelComponent = _statElements[_statElements.Count];
                    Destroy(statsElementPanelComponent.gameObject);
                    _statElements.RemoveAt(_statElements.Count);
                }
            }
        }
    }
}