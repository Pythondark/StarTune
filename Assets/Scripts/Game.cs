using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using ST.Core;
using ST.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    // Round Scriptable object variables:
    PianoKey.Note[] possibleNotes;
    float roundEnterTime;
    float roundLeaveTime;
    int totalNumberOfRounds;
    float wrongGuessDamage;

    
    // ====

    bool gameIsOver = false;
    bool playerHasAnswered = false;


    Round round;
    [SerializeField] Round defaultRound;
    [SerializeField] Round loadedRound;

    NotePlayer notePlayer;
    PianoKey.Note playerGuess;
    Health playerHealth;
    int roundNumber = 0;
    [SerializeField] TextMeshProUGUI gameMessageLine1;
    [SerializeField] TextMeshProUGUI roundsRemainingUI;

    bool roundLoaded = false;

    private void Awake()
    {
        round = FindObjectOfType<SceneLoader>().GetRoundToLoad();
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
    
        notePlayer = FindObjectOfType<NotePlayer>();
        playerHealth = FindObjectOfType<PlayerController>().GetComponent<Health>();
        gameMessageLine1.text = "";

        //round = defaultRound;
        //yield return new WaitForSeconds(1);
        
        SetupRoundData();

        print("Game Started");

        while (!gameIsOver)
        {
            print("=== START OF THE ROUND ===");
            playerHasAnswered = false;
            roundNumber++;
            roundsRemainingUI.text = "(" + roundNumber + "/" + totalNumberOfRounds + ")";

            // Wait Entry time
            yield return new WaitForSeconds(roundEnterTime);

            // Play Note
            PianoKey.Note note = PlayRandomNote();
            print("Random note: " + note);

            // Wait for input...        
            yield return new WaitUntil(() => playerHasAnswered == true);

            // Check to see if input matches the note
            bool correctGuess = false;
            correctGuess = (note == playerGuess) ? true : false;

            // If the guess is incorrect, player takes damage
            if (correctGuess)
            {
                FindObjectOfType<PlayerController>().Boost();
            }
            else
            {
                TakeDamage(wrongGuessDamage);
            }

            // Check if the player is dead 
            if (playerHealth.IsDead())
            {
                gameIsOver = true;
                gameMessageLine1.text = "LOSE!";
            }

            // Check if we have played all the rounds
            if (roundNumber >= totalNumberOfRounds)
            {
                gameIsOver = true;
                gameMessageLine1.text = "WIN!";
            }



            print("=== END OF THE ROUND ===");
            yield return new WaitForSeconds(roundLeaveTime);
        }
    }

    public void SetLoadedRound(Round round)
    {
        loadedRound = round;
        roundLoaded = true;
        print("round was loaded");
    }


    private void SetupRoundData()
    {
        possibleNotes = round.GetPossibleNotes();
        roundEnterTime = round.GetRoundEnterTime();
        roundLeaveTime = round.GetRoundLeaveTime();
        totalNumberOfRounds = round.GetTotalNumberOfRounds();
        wrongGuessDamage = round.GetWrongGuessDamage();
    }

    private void TakeDamage(float damage)
    {
        playerHealth.TakeDamage(damage);
    }


    private PianoKey.Note PlayRandomNote()
    {
        PianoKey.Note note = possibleNotes[Random.Range(0, possibleNotes.Length)];
        notePlayer.PlayNote(note);
        return note;
    }

    public void PlayerGuesses(PianoKey.Note note)
    {
        playerGuess = note;
        playerHasAnswered = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
