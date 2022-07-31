using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    public void AttackRate(int power, float time)
    {
        gameObject.GetComponent<PlayerAttack2>().fireRate += power;
        StartCoroutine(DecriseAttackRate(power, time));
    }
    IEnumerator DecriseAttackRate(int power, float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<PlayerAttack2>().fireRate -= power;
        StopCoroutine("DecriseAttackRate");
    }
}
