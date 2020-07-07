using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private OrganismTerritory _playerTerritory;

    private Slider _satietySlider;
    private Text _numberOfEnemiesUI;
    private Text _numberOfPlayersUI;
    private Player _player;
    private GameObject _pumpingButton;
    private GameObject _createADescendantButton;

    private void Start()
    {
        _satietySlider = GameObject.Find("SatietySlider").GetComponent<Slider>();

        _numberOfPlayersUI = GameObject.Find("NumberOfPlayers").GetComponent<Text>();
        _numberOfEnemiesUI = GameObject.Find("NumberOfEnemies").GetComponent<Text>();

        _playerTerritory = GameObject.FindGameObjectWithTag("PlayerTerritory").GetComponent<PlayerTerritory>();
        _player = this.GetComponent<Player>();

        _pumpingButton = GameObject.Find("PumpingButton");

        _createADescendantButton = GameObject.Find("CreateADescendantButton");
        _createADescendantButton.SetActive(false);
    }

    private void Update()
    {
        _satietySlider.value = _player.satiety;
        _numberOfPlayersUI.text = (PlayerTerritory.NumberOfPlayers).ToString();
        _numberOfEnemiesUI.text = (EnemyTerritory.NumberOfEnemies).ToString();

        if (_playerTerritory.CanCreateADescendant)
        {
            _createADescendantButton.SetActive(true);
        }
        else
        {
            _createADescendantButton.SetActive(false);
        }
    }    
}
