using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineController : MonoBehaviour {

    [SerializeField]
    private GameObject pinPrefab;

    [SerializeField]
    private float pinSpeed;

    [SerializeField]
    private float minTimeBetweenPins;

    [SerializeField]
    private float maxTimeBetweenPins;

    [SerializeField] 
    private float jumpLeeway;

    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform jumpPoint;
    [SerializeField]
    private Transform endPoint;

    private float _timeToNextPin = 0f;
    private bool _spinning = false;

    private Queue<ClothesPin> comingPins = new Queue<ClothesPin>();

    private Queue<ClothesPin> goingPins = new Queue<ClothesPin>();

    public ClothesPin currentPin 
    {
        get { return comingPins.Peek(); }   
    }

    public void StartSpinning()
    {
        _spinning = true;
        _timeToNextPin = Random.Range(minTimeBetweenPins, maxTimeBetweenPins);
    }

    public void StopSpinning()
    {
        _spinning = false;
    }

    public void PlacePin(ClothesPin pin)
    {
        pin.transform.position = startPoint.position;
        comingPins.Enqueue(pin);
    }

    public bool JumpPin(ClothesPinColor color)
    {
        ClothesPin pin = currentPin;

        if (pin == null)
        {
            return false;
        }

        if (color == pin.clothesColor)
        {
            if (Mathf.Abs(pin.transform.position.x - jumpPoint.position.x) <= jumpLeeway)
            {
                goingPins.Enqueue(comingPins.Dequeue());
                return true;
            }
        }

        return false;
    }

    public void Update()
    {
        if (_spinning)
        {
            if ((_timeToNextPin -= Time.deltaTime) <= 0f)
            {
                GameObject pin = Instantiate(pinPrefab);
                pin.GetComponent<ClothesPin>().clothesColor = (ClothesPinColor)Random.Range(0, 4);
                pin.transform.position = startPoint.position;
            }

            foreach (ClothesPin pin in goingPins)
            {
                pin.transform.localPosition += Vector3.left * pinSpeed * Time.deltaTime;
            }

            if (goingPins.Peek() != null)
            {
                if (goingPins.Peek().transform.position.x < endPoint.position.x)
                {
                    Destroy(goingPins.Dequeue().gameObject);
                }
            }

            foreach (ClothesPin pin in comingPins)
            {
                pin.transform.localPosition += Vector3.left * pinSpeed * Time.deltaTime;
            }

            if (comingPins.Peek() != null)
            {
                if (comingPins.Peek().transform.position.x < (jumpPoint.position.x - jumpLeeway))
                {
                    goingPins.Enqueue(comingPins.Dequeue());
                }
            }
        }
    }
}
