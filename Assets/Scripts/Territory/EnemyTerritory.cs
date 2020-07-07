using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : OrganismTerritory
{
    // коефіцієнти прокачки організма

    public static float theRateOfHungerReductionKoef = 0f;   //швидкість зменшення ситості
    public static float speedUpKoef = 0f; //швидкість
    public static float scaleUpKoef = 0f;  //розмір

    // шанси прокачки організма

    protected float chanceToIncreaseSpeed = 0f;    // шанс збільшення швидкосі
    protected float chanceToIncreaseScale = 0f;    // шанс збільшення розміру

    private void Start()
    {
        _organismTerritoryPosition = this.transform;
        _newOrganismPos = _organismTerritoryPosition.position;
        _newOrganismPos.y = _organismTerritoryPosition.position.y + 4f;
    }

    private void Update()
    {
        if (CanCreateADescendant)
        {
            CreateADescendant();
        }
    }

    public override void CreateADescendant()
    {
        base.CreateADescendant();

        NumberOfEnemies++;
    }
}
