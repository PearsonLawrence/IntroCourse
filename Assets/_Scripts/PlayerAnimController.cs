using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour {
    public PlayerController MyController;

    public void Reload()
    {
        MyController.gun.Mag = MyController.gun.MaxMag;
    }
}
