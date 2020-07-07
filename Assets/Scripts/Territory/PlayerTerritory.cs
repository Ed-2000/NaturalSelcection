using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTerritory : OrganismTerritory
{
    private Player _newOrganismParams;

    // коефіцієнти прокачки організма

    public static float theRateOfHungerReductionKoef = 0f;   //швидкість зменшення ситості
    public static float speedUpKoef = 0f; //швидкість
    public static float scaleUpKoef = 0f;  //розмір

    // шанси прокачки організма

    protected float chanceToIncreaseSpeed = 1f;    // шанс збільшення швидкосі
    protected float chanceToIncreaseScale = 0f;    // шанс збільшення розміру


    private void Start()
    {
        // визначаємо місце створення організму
        _organismTerritoryPosition = this.transform;
        _newOrganismPos = _organismTerritoryPosition.position;
        _newOrganismPos.y = _organismTerritoryPosition.position.y + 4f;
    }

    public override void CreateADescendant()
    {
        base.CreateADescendant();

        _newOrganismParams = _newOrganism.GetComponent<Player>();

        _newOrganismParams.speed += speedUpKoef;
        _newOrganismParams.scale += scaleUpKoef;
        _newOrganismParams.theRateOfHungerReduction -= theRateOfHungerReductionKoef;

        NumberOfPlayers++;        
    }
}
