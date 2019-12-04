using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ST.Core
{
    public class NotePlayer : MonoBehaviour
    {

        [SerializeField] AudioClip MiddleC;
        [SerializeField] AudioClip CSharp;
        [SerializeField] AudioClip D;
        [SerializeField] AudioClip DSharp;
        [SerializeField] AudioClip E;
        [SerializeField] AudioClip F;
        [SerializeField] AudioClip FSharp;
        [SerializeField] AudioClip G;
        [SerializeField] AudioClip GSharp;
        [SerializeField] AudioClip A;
        [SerializeField] AudioClip ASharp;
        [SerializeField] AudioClip B;
        [SerializeField] AudioClip HighC;

        public void PlayNote(PianoKey.Note note)
        {

            AudioClip noteSound;
            switch(note)
            {
                case PianoKey.Note.CMiddle:
                    noteSound = MiddleC;
                    break;
                case PianoKey.Note.CSharp:
                    noteSound = CSharp;
                    break;
                case PianoKey.Note.D:
                    noteSound = D;
                    break;
                case PianoKey.Note.DSharp:
                    noteSound = DSharp;
                    break;
                case PianoKey.Note.E:
                    noteSound = E;
                    break;
                case PianoKey.Note.F:
                    noteSound = F;
                    break;
                case PianoKey.Note.FSharp:
                    noteSound = FSharp;
                    break;
                case PianoKey.Note.G:
                    noteSound = G;
                    break;
                case PianoKey.Note.GSharp:
                    noteSound = GSharp;
                    break;
                case PianoKey.Note.A:
                    noteSound = A;
                    break;
                case PianoKey.Note.ASharp:
                    noteSound = ASharp;
                    break;
                case PianoKey.Note.B:
                    noteSound = B;
                    break;
                case PianoKey.Note.CHigh:
                    noteSound = HighC;
                    break;
                default:
                    noteSound = MiddleC;
                    break;
            }


            AudioSource.PlayClipAtPoint(noteSound, Camera.main.transform.position, 1f);
        }
    }
}

