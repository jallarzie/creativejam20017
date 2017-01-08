using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewSequence", order = 1, menuName = "Sequence")]
public class SequenceObject : ScriptableObject {
    public float length;

    public string soundEvent;

    public float[] timings;
}
