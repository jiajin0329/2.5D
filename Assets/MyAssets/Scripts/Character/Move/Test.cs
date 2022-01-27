using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public class Deck {
        public Deck(int i, int j, bool used) {

        }

        public Deck() {

        }

        public Deck(int i) {

        }
    }

    public Deck[] deck = new Deck[52];

    void Start() {
        deck[0] = new Deck(1, 2, true);
    }
}
