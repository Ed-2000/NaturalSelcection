using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private GameObject _pumpingPanel;
    private GameObject _chanceOfPumpingPanel;
    private GameObject _koefOfPumpingPanel;

    private void Start()
    {      
        _chanceOfPumpingPanel = GameObject.Find("ChanceOfPumpingPanel");
        _koefOfPumpingPanel = GameObject.Find("KoefOfPumpingPanel");
        _koefOfPumpingPanel.SetActive(false);
        _pumpingPanel = GameObject.Find("PumpingPanel");
        _pumpingPanel.SetActive(false);
    }

    public void OpenAndClosePumpingPanel()
    {
        _pumpingPanel.SetActive(!_pumpingPanel.activeSelf);
    }

    public void OpenChanceOfPumpingPanel()
    {
        if (!_chanceOfPumpingPanel.activeSelf)
        {
            _chanceOfPumpingPanel.SetActive(true);
            _koefOfPumpingPanel.SetActive(false);
        }
    }

    public void OpenKoefOfPumpingPanel()
    {
        if (!_koefOfPumpingPanel.activeSelf)
        {
            _koefOfPumpingPanel.SetActive(true);
            _chanceOfPumpingPanel.SetActive(false);
        }
    }

    public void SpeedUp()
    {
        PlayerTerritory.speedUpKoef += PlayerTerritory.speedUpKoef * 0.05f;
    }
}
