using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ST.Core;

[CreateAssetMenu(menuName = "Round")]
public class Round : ScriptableObject
{
    [SerializeField] string roundName = "Default";

    [SerializeField] PianoKey.Note[] possibleNotes;
    [SerializeField] [Range(0, 5)] float roundEnterTime = 2f;
    [SerializeField] [Range(0, 5)] float roundLeaveTime = 2f;
    [SerializeField] int totalNumberOfRounds = 3;
    [SerializeField] float wrongGuessDamage = 34f;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PianoKey.Note[] GetPossibleNotes() { return possibleNotes; }
    public float GetRoundEnterTime() { return roundEnterTime; }
    public float GetRoundLeaveTime() { return roundEnterTime; }
    public int GetTotalNumberOfRounds() { return totalNumberOfRounds; }
    public float GetWrongGuessDamage() { return wrongGuessDamage; }
    public string GetRoundName() { return roundName; }
}
