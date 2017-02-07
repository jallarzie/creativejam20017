using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineController : MonoBehaviour {

    [SerializeField]
    private GameObject pinPrefab;

    [SerializeField]
    private float pinSpeed;

    [SerializeField]
    private float bpm;

    [SerializeField] 
    private float jumpLeeway;

    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform jumpPoint;
    [SerializeField]
    private Transform endPoint;
    
    [SerializeField]
    private SecondaryPController player;

    [SerializeField]
    private AudioSource sequenceSoundSource;

    [SerializeField]
    private AudioSource extraSoundSource;

    [SerializeField]
    private TextAsset sequence;
    
    private int sequenceIndex = 0;

    private float _timeToNextPin = 0f;
    public bool spinning { get { return sequenceIndex < sequence.text.Length; } }

    private Queue<ClothesPin> comingPins = new Queue<ClothesPin>();

    private Queue<ClothesPin> goingPins = new Queue<ClothesPin>();

    private Queue<ClothesPin> placedPins = new Queue<ClothesPin>();

    public ClothesPin currentPin 
    {
        get { return comingPins.Count > 0 ? comingPins.Peek() : null; }   
    }

    public float birdStopPosition
    {
        get { return jumpPoint.position.x; }
    }
    
    public void PlacePin(ClothesPin pin)
    {
        pin.transform.position = startPoint.position;
        pin.transform.SetParent(null);
        placedPins.Enqueue(pin);
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
            if (jumpPoint.position.x <= (pin.transform.position.x + jumpLeeway) && jumpPoint.position.x >= (pin.transform.position.x - jumpLeeway))
            {
                comingPins.Dequeue();
                pin.Hide();
                goingPins.Enqueue(pin);

                sequenceSoundSource.mute = false;

                return true;
            }
        }

        return false;
    }

    private void Start()
    {
        _timeToNextPin = 0f;
        SpawnPin();
    }

    private void Update()
    {
        foreach (ClothesPin pin in goingPins)
        {
            pin.transform.localPosition += Vector3.left * pinSpeed * Time.deltaTime;
        }

        if (goingPins.Count > 0)
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

        if (comingPins.Count > 0)
        {
            if (comingPins.Peek().transform.position.x < (jumpPoint.position.x - jumpLeeway))
            {
                goingPins.Enqueue(comingPins.Dequeue());
                player.Stumble();
                sequenceSoundSource.mute = true;
            }
        }

        _timeToNextPin -= Time.deltaTime;

        if (_timeToNextPin <= 0f)
        {
            SpawnPin();
        }
    }

    private void SpawnPin()
    {
        if (sequenceIndex < sequence.text.Length)
        {
            char nextPin = sequence.text[sequenceIndex++];

            if (nextPin != 'x' && nextPin != 'X')
            {
                ClothesPin pin = Instantiate(pinPrefab).GetComponent<ClothesPin>();
                switch (nextPin)
                {
                    case 'G':
                        pin.clothesColor = ClothesPinColor.Green;
                        break;
                    case 'B':
                        pin.clothesColor = ClothesPinColor.Blue;
                        break;
                    case 'R':
                        pin.clothesColor = ClothesPinColor.Red;
                        break;
                    case 'Y':
                        pin.clothesColor = ClothesPinColor.Yellow;
                        break;
                }
                pin.transform.position = startPoint.position;
                comingPins.Enqueue(pin);
            }
            else
            {
                if (placedPins.Count > 0)
                {
                    comingPins.Enqueue(placedPins.Dequeue());
                }
            }
        }

        _timeToNextPin = 15f / bpm + _timeToNextPin;
    }
}
