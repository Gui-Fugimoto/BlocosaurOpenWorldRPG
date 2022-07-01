using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleState state;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogText.text = "Um " + enemyUnit.unitName + " agressivo apareceu!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogText.text = "Blocossauro atacou!";
        //damage the enemy
        yield return new WaitForSeconds(2f);
        //check if enemy dead

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
            // end the battle
        } else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
            // Enemy Turn;
        }
        //change state based on that

    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(15);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogText.text = "Blocossauro comeu uma fruta!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        dialogText.text = enemyUnit.unitName + " atacou!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogText.text = "Blocossauro venceu!";
        }else if (state == BattleState.LOST)
        {
            dialogText.text = "Blocossauro perdeu...";
        }
    }
    void PlayerTurn()
    {
        dialogText.text = "O que Blocossauro vai fazer?";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
        
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());

    }
}
