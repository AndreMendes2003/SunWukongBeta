using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;
    public int maxHealth;
    private int currentHealth;
    private bool isDead = false;

    public float stopTimeAfterHit = 1f;  // Tempo que o inimigo ficará parado após receber dano
    private bool isMoving = true;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;  // Se o inimigo já estiver morto, não faça nada

        currentHealth -= damage;

        // Play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(StopMovementTemporarily());  // Para a movimentação após o hit
        }
    }

    void Die()
    {
        isDead = true;  // Define o estado como morto
        Debug.Log("Enemy died!");

        // Play death animation
        animator.SetBool("isDead", true);

        // Disable enemy movement and interaction
        GetComponent<Collider2D>().enabled = false;  // Desabilita o colisor
        isMoving = false;  // Impede a movimentação após a morte

        StartCoroutine(DisableAfterDeath());

        this.enabled = false;  // Desabilita este script para evitar qualquer ação adicional

    }

    IEnumerator StopMovementTemporarily()
    {
        isMoving = false;  // Impede a movimentação temporariamente
        yield return new WaitForSeconds(stopTimeAfterHit);  // Espera o tempo definido
        if (!isDead)  // Apenas reativa se o inimigo ainda não estiver morto
        {
            isMoving = true;  // Reativa a movimentação
        }
    }

    // Coroutine para aguardar o fim da animação + timer de 1 segundo antes de desabilitar completamente
    IEnumerator DisableAfterDeath()
    {
        // Aguarda o fim da animação de morte
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Adiciona o timer de 1 segundo após a animação de morte
        yield return new WaitForSeconds(2f);

        // Desabilita o GameObject do inimigo completamente
        gameObject.SetActive(false);  // Ou use Destroy(gameObject) para remover completamente
    }
}
