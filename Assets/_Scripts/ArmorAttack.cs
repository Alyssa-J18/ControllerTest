using UnityEngine;

public class ArmorEnemy : MonoBehaviour
{
    private Animator anim;

    public Collider2D swordCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("armorAnimation", 0, Random.value);
        swordCollider.enabled = false;
    }

    public void EnableDamage()
    {
        swordCollider.enabled = true;
    }

    public void DisableDamage()
    {
        swordCollider.enabled = false;
    }
}