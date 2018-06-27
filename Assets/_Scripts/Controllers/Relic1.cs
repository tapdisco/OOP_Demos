using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Relic1 : MonoBehaviour 
{
    //Each round will spawn a number of spirits (List of rounds and number of spirits in each round)
    //Rounds launch at a specific time interval (every 5 seconds)
    //And Spirits spawn at a specific time interval within the round

    [SerializeField] private GameObject _spiritPrefab;

    [SerializeField] private int _maxRounds = 2;
    [SerializeField] private int _maxSpirits = 5;
    [SerializeField] private float _spiritSpawnInterval = 1f;
    private int _spiritsSpawned = 0;
    private float _nextSpiritSpawnTime;

    private float _nextRoundStartTime;
    private float _roundInterval = 10.0f;
    private int _currentRound = 1;
    private int _nextRound = 2;

    //below: need a float for maxSpirits to calc the slider position
    private float _maxSpiritsFloat = 5f;
    //These are the other level progress variables and UI instance/access
    public float spiritsCaptured = 0;
    [SerializeField] private float _spiritsCaptureTarget = 5;
    [SerializeField] private bool _levelSuccess = false;
    public Slider spiritsCapturedIndicator;

    public UnityEvent OnLevelSuccess;
    public UnityEvent OnLevelFail;
	
    // Use this for initialization
	void Start () {
        _nextRoundStartTime = Time.time + _roundInterval;
        _nextSpiritSpawnTime = Time.time + _spiritSpawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
        if (_levelSuccess)
        {
            return;
        }
        else if (spiritsCaptured == _spiritsCaptureTarget)
        {
            OnLevelSuccess.Invoke();
            _levelSuccess = true;
        }
        if (_currentRound > _maxRounds)
        {
            //Debug.Log("NO MORE ROUNDS");
        }
        else if(Time.time < _nextRoundStartTime)
        {
            //Debug.Log("ROUND" + _currentRound);
            SpawnSpirits();
        }
        else if (Time.time >= _nextRoundStartTime)
        {
            _nextRoundStartTime = Time.time + _roundInterval;
            _currentRound++;
        }

        spiritsCapturedIndicator.value = spiritsCaptured / _maxSpiritsFloat;
        Debug.Log("CAPTURED SPIRITS = " + spiritsCapturedIndicator.value);
	}

    private void SpawnSpirits()
    {
        if(_spiritsSpawned == _maxSpirits)
        {
            return;
        }
        else if(Time.time < _nextSpiritSpawnTime)
        {
            return;
        }
        else if (Time.time >= _nextSpiritSpawnTime)
        {
            Instantiate(_spiritPrefab,transform.position + new Vector3(Random.Range(-1.0f,1.0f),0.15f,Random.Range(-1.0f, 1.0f)),Quaternion.identity);
            _nextSpiritSpawnTime = Time.time + _spiritSpawnInterval;
        }
    }
}
