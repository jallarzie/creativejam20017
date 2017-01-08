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
    private AudioClip[] soundClips;

    [SerializeField]
    private TextAsset sequence;

    private int soundIndex = 0;

    private int sequenceIndex = 0;

    private float _timeToNextPin = 0f;
    public bool spinning { get; private set; }

    private Queue<ClothesPin> comingPins = new Queue<ClothesPin>();

    private Queue<ClothesPin> goingPins = new Queue<ClothesPin>();

    public ClothesPin currentPin 
    {
        get { return comingPins.Count > 0 ? comingPins.Peek() : null; }   
    }

    public float birdStopPosition
    {
        get { return jumpPoint.position.x; }
    }

    public void StartSpinning()
    {
        spinning = true;        
    }

    public void StopSpinning()
    {
        spinning = false;
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
            if (comingPins.Peek().transform.position.x <= jumpPoint.position.x)
            {
                goingPins.Enqueue(comingPins.Dequeue());
                sequenceSoundSource.PlayOneShot(soundClips[soundIndex++]);
                player.Stumble();
            }
        }

        if ((_timeToNextPin -= Time.deltaTime) <= 0f)
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
            }

            _timeToNextPin = 15f / bpm;
        }
    }
}
