using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Organism
{
    private float _horInput;
    private float _vertInput;
    private float _moveLimit;
    private Transform _centerOfMass;
    private Transform _playerTransform;
    private Transform _playerBody;
    private Rigidbody _rb;
    private Joystick _joystick;

    
    private void Start()
    {
        _playerTransform = this.transform;
        _playerBody = transform.GetChild(0).transform;

        _moveLimit = GroundParameters.Width / 2 - 1.5f;

        _joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();

        _centerOfMass = transform.Find("CenterOfMass");
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = _centerOfMass.localPosition;
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
        }
        Move();
    }
    
    private void Move() //переміщення гравця
    {
        _vertInput = _joystick.Vertical();
        _horInput = _joystick.Horizontal();        

        Vector3 moveVector = new Vector3(_horInput, 0, _vertInput) * speed * Time.deltaTime;

        _playerBody.LookAt(moveVector  + transform.position);

        _playerTransform.Translate(moveVector);
    }

    //private void MoveLimit()    //обмежує переміщення гравця
    //{
    //    Vector3 limitVector = _playerTransform.position;

    //    if (_playerTransform.position.x >= _moveLimit)
    //    {
    //        limitVector.x = _moveLimit;
    //    }
    //    else if (_playerTransform.position.x <= -_moveLimit)
    //    {
    //        limitVector.x = -_moveLimit;
    //    }
    //    else if (_playerTransform.position.z >= _moveLimit)
    //    {
    //        limitVector.z = _moveLimit;
    //    }
    //    else if (_playerTransform.position.z <= -_moveLimit)
    //    {
    //        limitVector.z = -_moveLimit;
    //    }

    //    _playerTransform.position = limitVector;
    //}
}
