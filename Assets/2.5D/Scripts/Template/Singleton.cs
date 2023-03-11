using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {
    static Singleton _singleton;
    public static Singleton get {get{return _singleton;}}
    Singleton() {}

    void Awake() {
        _singleton = null;
        _singleton = this;
    }
}