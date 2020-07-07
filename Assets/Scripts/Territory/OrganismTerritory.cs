using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismTerritory : MonoBehaviour
{
    public static int NumberOfPlayers { get; set; } = 1;
    public static int NumberOfEnemies { get; set; } = 1;
    public bool CanCreateADescendant { get; protected set; } = false; // чи можна створити нащадка


    public int amoundOfFoodYouNeed = 5;    // кількість їжі необхіда для створення нащадка
    public Transform _organismTerritoryPosition; // розташування цієї території

    [SerializeField] private GameObject _aDescendantOrganism; // організм-нащадок цієї території

    protected int _amoundOfFood = 0; // поточна кількість їжі
    protected GameObject _organism;   // організм, що контактує з територією
    protected Organism _parameterOfNewOrganism;   // породжуваний організм
    protected Vector3 _newOrganismPos;   // позиція породжуваного організму
    protected GameObject _newOrganism; // породжуваний організм


    public virtual void CreateADescendant()
    {
        _newOrganism = Instantiate(_aDescendantOrganism, _newOrganismPos, Quaternion.identity);

        CanCreateADescendant = false;
        _amoundOfFood -= amoundOfFoodYouNeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            _organism = other.gameObject;

            if (_organism.GetComponent<Organism>().hasExtraFood == true)
            {
                _amoundOfFood++;
                _organism.GetComponent<Organism>().hasExtraFood = false;
            }

            if (_amoundOfFood >= amoundOfFoodYouNeed)
            {
                CanCreateADescendant = true;
            }                        
        }
    }
}
