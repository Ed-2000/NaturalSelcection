using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorGenerator : MonoBehaviour
{
    public static bool allActiveFoodPrefabsIsActive = true;

    [SerializeField] private List<GameObject> _decorPrefab;

    private float _theLimitOfDecorCreation; //межа спавну
    private float _distanceFromTheEdgeOfTheGround = 1f; //відступ від країв землі
    private int _numberOfDecorPrefabs = 250;   //кількість на землі
    private GameObject newDecor;

    private void Start()
    {
        _theLimitOfDecorCreation = GroundParameters.Width / 2 - _distanceFromTheEdgeOfTheGround;

        for (int i = 0; i < _numberOfDecorPrefabs; i++)
        {
            newDecor = Instantiate(_decorPrefab[Random.Range(0, _decorPrefab.Count)]);
            newDecor.transform.position = GetARandomPositionForXAndZ();
        }
    }

    private Vector3 GetARandomPositionForXAndZ() //задаємо позицію GameObject по x та z
    {
        Vector3 pos = new Vector3();
        float limit = _theLimitOfDecorCreation;

        pos.x = Random.Range(-limit, limit);
        pos.y = 0.5f;
        pos.z = Random.Range(-limit, limit);

        return pos;
    }
}
