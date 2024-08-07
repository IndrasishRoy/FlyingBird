using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pipe;
    [SerializeField]
    private float _spawnRate = 2f;
    private float timer = 0;
    [SerializeField]
    private float _gapSizeX = 2f;
    [SerializeField]
    private float _offSetY = 4f;
    private Vector3 _lastPipePosition;
    [SerializeField]
    private GameObject _background;

    void Start()
    {
        _lastPipePosition = transform.position;
        spawnPipe();
    }

    void Update()
    {
        if (timer < _spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = _background.transform.position.y - (_background.transform.localScale.y / 2) + _offSetY;
        float highestPoint = _background.transform.position.y + (_background.transform.localScale.y / 2) - _offSetY;
        float pipeY = Random.Range(lowestPoint, highestPoint);

        Vector3 pipePosition = new Vector3(_lastPipePosition.x + _gapSizeX, pipeY, 0);
        GameObject newPipe = Instantiate(_pipe, pipePosition, Quaternion.identity);
        newPipe.transform.SetParent(_background.transform, false);
        _lastPipePosition = pipePosition;
    }
}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pipe;
    [SerializeField]
    private float _spawnRate = 2f;
    private float timer = 0;
    [SerializeField]
    private float _gapSizeX = 5f;
    [SerializeField]
    private float _offSetY = 6f;
    private Vector3 _lastPipePosition;
    void Start()
    {
        spawnPipe();
    }
    void Update()
    {
        if(timer < _spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - _offSetY;
        float highestPoint = transform.position.y + _offSetY;
        float pipeY = Random.Range(lowestPoint, highestPoint);

        Vector3 pipePosition = new Vector3(_lastPipePosition.x + _gapSizeX, pipeY, 0);
        Instantiate(_pipe, pipePosition, transform.rotation);
        _lastPipePosition = pipePosition;
    }
}
*/