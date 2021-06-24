using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public bool Jump => _jump;

    private float _lerpTime;
    private float _currentLerpTime;
    private float _percent = 1;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private bool _firstInput;
    private bool _jump;

    void Update()
    {
        if (Input.GetButtonDown("up") || Input.GetButtonDown("down") ||
            Input.GetButtonDown("left") || Input.GetButtonDown("right"))
        {
            if (_percent == 1)
            {
                _lerpTime = 1;
                _currentLerpTime = 0;
                _firstInput = true;
                _jump = true;
            }
        }

        _startPosition = gameObject.transform.position;

        if (Input.GetButtonDown("right") && gameObject.transform.position == _endPosition)
        {
            _endPosition = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }

        if (Input.GetButtonDown("left") && gameObject.transform.position == _endPosition)
        {
            _endPosition = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }

        if (Input.GetButtonDown("up") && gameObject.transform.position == _endPosition)
        {
            _endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }

        if (Input.GetButtonDown("down") && gameObject.transform.position == _endPosition)
        {
            _endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }

        if (_firstInput == true)
        {
            _currentLerpTime += Time.deltaTime * 5f;
            _percent = _currentLerpTime / _lerpTime;
            gameObject.transform.position = Vector3.Lerp(_startPosition, _endPosition, _percent);
            if (_percent > 0.8f)
            {
                _percent = 1;
            }
            if (Mathf.Round(_percent) == 1)
            {
                _jump = false;
            }
        }
    }
}