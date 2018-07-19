using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimationManager : MonoBehaviour {

    public AIMonsterController Controller;

    public GameObject HitBox;

	public void StartAttack()
    {
        HitBox.SetActive(true);
    }

    public void EndDamage()
    {
        HitBox.SetActive(false);
    }

    public void EndAttack()
    {
        Controller.SetAttackCooldown = Controller.AttackCooldown;
    }
}
