using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Organism
{
    private Vector3 _territory;
    private NavMeshAgent _agent;
    private Vector3 _targetPosition;
    private float _groundHalfWidth;
    private string _nameOfTerritory;

    private void Start()
    {        
        if (this.tag == "Enemy")
        {
            _territory = GameObject.Find("EnemyTerritory").GetComponent<EnemyTerritory>().transform.position;
        }
        else
        {
            _territory = GameObject.Find("PlayerTerritory").GetComponent<PlayerTerritory>().transform.position;
        }

        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        _targetPosition = SetRandomTargetPosition();
        _groundHalfWidth = GroundParameters.Width / 2 - 5;
    }

    private void Update()
    {
        ReducingHunger();  //зменшення ситості зі швидкістю _theRateOfHungerReduction 
        if (satiety <= 0)
        {
            Dead();
        }
        ShowsBuddingFood();

        if (hasExtraFood)
        {
            EatOrTake();
            _targetPosition = _territory;
        }
        else if (_foodObject == null)
        {
            if (Random.value < 0.001 || IsApproximatlyEqualTo(this.transform.position, this._targetPosition, 0.75f))    //шанс змінити цільову точку в кожному кадрі = 0,001
            {
                _targetPosition = SetRandomTargetPosition();
            }            
        }

        if (IsLive)
        {
            _agent.destination = _targetPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            _foodObject = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_foodObject != null)
        {
            _targetPosition = _foodObject.transform.position;
        }

        if (_foodObject == null && other.tag == "Food")
        {
            _foodObject = other.gameObject;
            _targetPosition = _foodObject.transform.position;
        }
    }

    private bool IsApproximatlyEqualTo(Vector3 tr1, Vector3 tr2, float accuracy)
    {
        bool res = false;
        accuracy = Mathf.Abs(accuracy);
        if ( (tr1.x + accuracy >= tr2.x && tr1.z + accuracy >= tr2.z) && (tr1.x - accuracy <= tr2.x && tr1.z - accuracy <= tr2.z))
        {
            res = true;
        }
        return res;
    }

    private Vector3 SetRandomTargetPosition()
    {
        Vector3 pos = new Vector3(Random.Range(-_groundHalfWidth, _groundHalfWidth), 0, Random.Range(-_groundHalfWidth, _groundHalfWidth));
        print("SetRandomTargetPosition: " + pos);

        return pos;
    }
}
