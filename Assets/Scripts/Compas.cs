using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compas : MonoBehaviour
{
    private Player _player;
    private Transform _playerTransform;
    private Transform _playerTerritory;

    private float _compasAngle;
    private int _horKoef = 1;
    private int _vertKoef = 0;

    private Vector3 _wall;
    private Vector3 _vectorFromPlayerToBase;
    private Vector3 _vectorFromPlayerToWall;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();   //!
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;    //!
        _playerTerritory = GameObject.FindGameObjectWithTag("PlayerTerritory").transform;
    }

    private void Update()
    {
        _wall = _playerTransform.position;
        _wall.z = _playerTerritory.position.z ;

        _vectorFromPlayerToBase = _playerTerritory.position - _playerTransform.position;
        _vectorFromPlayerToWall = _wall - _playerTransform.position;

        _vectorFromPlayerToBase.y = 0;
        _vectorFromPlayerToWall.y = 0;

        _compasAngle = Vector3.Angle(_vectorFromPlayerToBase, _vectorFromPlayerToWall);

        if (_playerTransform.position.x >= _playerTerritory.position.x) _horKoef = -1;
        else _horKoef = 1;

        if (_playerTransform.position.z <= _playerTerritory.position.z)
        {
            _vertKoef = 1;
            _horKoef = -_horKoef;
        }
        else _vertKoef = 0;

        transform.localEulerAngles = new Vector3(90, 0, _horKoef * _compasAngle + _vertKoef * 180);
    }
}
