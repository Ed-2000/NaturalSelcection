using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public static bool allActiveFoodPrefabsIsActive = true;

    [SerializeField] private GameObject _foodPrefab;

    private List<GameObject> _createdFood;
    private List<GameObject> _activeFood;
    private float _theLimitOfFoodCreation; //межа спавну їжі
    private float _distanceFromTheEdgeOfTheGround = 10f; //відступ від країв землі
    private int _numberOfFoodPrefabs = 25;   //кількість активної їжі на землі
    

    private void Start()
    {
        _theLimitOfFoodCreation = GroundParameters.Width / 2 - _distanceFromTheEdgeOfTheGround;

        _createdFood = new List<GameObject>();
        _activeFood = new List<GameObject>();

        for (int i = 0; i < _numberOfFoodPrefabs; i++)
        {
            _activeFood.Add(Instantiate(_foodPrefab));
            _activeFood[i].transform.position = GetARandomPositionForXAndZ(); //задаємо позицію префабу їжі
        }
    }

    private void Update()
    {
        if (_activeFood.Count < _numberOfFoodPrefabs)
        {
            FoodActivator();
        }

        if (allActiveFoodPrefabsIsActive == false)
        {
            FoodDeactivator();
            allActiveFoodPrefabsIsActive = true;
        }
    }

    private void FoodActivator()
    {
        _activeFood.Add(_createdFood[_createdFood.Count - 1]);
        _activeFood[_activeFood.Count - 1].transform.position = GetARandomPositionForXAndZ(); //задаємо позицію префабу їжі
        _activeFood[_activeFood.Count - 1].SetActive(true);

        _createdFood.RemoveAt(_createdFood.Count - 1);
    }

    private void FoodDeactivator()
    {
        for (int i = 0; i < _activeFood.Count; i++)
        {
            if (!_activeFood[i].activeInHierarchy)
            {
                _createdFood.Add(_activeFood[i]);
                _activeFood.RemoveAt(i);
                break;
            }
        }
    }

    private Vector3 GetARandomPositionForXAndZ() //задаємо позицію GameObject по x та z
    {
        Vector3 pos = new Vector3();
        float limit = _theLimitOfFoodCreation;

        pos.x = Random.Range(-limit, limit);
        pos.y = 3;
        pos.z = Random.Range(-limit, limit);

        return pos;
    }
}