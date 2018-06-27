using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour {

    //movement variables
    private Vector3 _direction;
    [SerializeField] private float _speed = 0.3f;
    [SerializeField] private float _rotateSpeed = 0.0f; //might not need this...using Torque in constant force component

    //spirit lifetime variables...life should be passed in from the Relic's class
    [SerializeField] private float _spiritLifeTest = 10f;
    private float _spiritTimeStarted;
    private float _currentSpiritDuration;
    //will use this when connected to a game relic to get access to its class
    private Relic1 _relic1;

    [SerializeField] private GameObject _spiritCapturedFXPrefab;


    private Animator _anim;


    // Use this for initialization
    void Start () {
        _spiritTimeStarted = Time.time;
        _direction = new Vector3(Random.Range(-0.4f, 0.4f), 0.3f, 0.0f);

        _relic1 = Object.FindObjectOfType<Relic1>();

        //Saving these for future reference...reference to the Relic object and it's class...
        //stuf for animation.
        //_anim = GetComponent<Animator>();
        //_anim.SetBool("Spirit_Start", true);
        //_relic = GameObject.Find("Relic").GetComponent<Relic>();
	}
	
	void Update () {
        SpiritLife();
        SpiritMovement();
	}

    private void SpiritLife()
    {
        _currentSpiritDuration = Time.time - _spiritTimeStarted;

        if (_currentSpiritDuration > _spiritLifeTest)
        {
            Destroy(this.gameObject);
        }
    }

    private void SpiritMovement()
    {
        Vector3 movement = _direction * _speed;
        transform.Translate(movement * Time.deltaTime);
        //transform.Rotate(Vector3.right, _rotateSpeed * Time.deltaTime);
    }

    public void CaptureSpirit()
    {
        _relic1.spiritsCaptured++;
        Instantiate(_spiritCapturedFXPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
