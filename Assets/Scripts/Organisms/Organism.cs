using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Organism : MonoBehaviour
{
    public bool IsLive { get; private set; } = true;

    //=== прокачувані параметри організма ===//

    public float theRateOfHungerReduction = 2f;   //швидкість зменшення ситості
    public float speed = 5f; //швидкість
    public float scale = 1f;  //розмір

    //=== ===//

    public GameObject _foodObject;
    public bool hasExtraFood = false;   //визначає чи має істота їжу, яку варто віднести на базу
    public float satiety = 50f;  //ситiсть

    public GameObject _butaphoricFood;
    [SerializeField] private UnityEvent _OnEat;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food" && !hasExtraFood)
        {
            _foodObject = collision.gameObject;

            _foodObject.SetActive(false);
            FoodGenerator.allActiveFoodPrefabsIsActive = false;
            _foodObject = null;

            hasExtraFood = true;
            EatOrTake();
        }
    }

    public void EatOrTake()
    {
        if (satiety < 50 && hasExtraFood)
        {
            if (_OnEat != null)
            {
                _OnEat.Invoke();
            }
            satiety = 100f;
            hasExtraFood = false;
        }
    }

    public void Dead()
    {
        GameObject org = this.gameObject;

        IsLive = false;
        org.SetActive(false);

        if (org.tag == "Player")
        {
            OrganismTerritory.NumberOfPlayers--;
        }
        else if (org.tag == "Enemy")
        {
            OrganismTerritory.NumberOfEnemies--;
        }
    }

    public void ShowsBuddingFood()   //активація або деaктивація ефекту транспортування їжі
    {
        if (hasExtraFood)
        {
            _butaphoricFood.SetActive(true);
        }
        else
        {
            _butaphoricFood.SetActive(false);
        }
    }

    public void ReducingHunger()  //зменшення ситості
    {
        satiety = Mathf.MoveTowards(satiety, 0, theRateOfHungerReduction * Time.deltaTime);
    }
}
