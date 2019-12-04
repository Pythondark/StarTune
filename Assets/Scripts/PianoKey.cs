using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ST.Core
{


    public class PianoKey : MonoBehaviour
    {

        [SerializeField] Note myNote;

        public enum Note
        {
            CMiddle, CSharp, D, DSharp, E, F, FSharp, G, GSharp, A, ASharp, B, CHigh
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void HitKey()
        {
            FindObjectOfType<NotePlayer>().PlayNote(myNote);
            FindObjectOfType<Game>().PlayerGuesses(myNote);
        }
    }
}


