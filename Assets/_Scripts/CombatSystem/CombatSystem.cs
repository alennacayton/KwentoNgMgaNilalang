using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class CombatSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleState state;

    public Text dialogueText;

    public CombatHUD playerHUD;
    public CombatHUD enemyHUD;

    void Start()
    {
        state = BattleState.START; 
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        // Instantiate/Create the player model
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        // Instantiate/Create the enemy model
        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        dialogueText.text = "The mythical creature, " + enemyUnit.unitName + ", approaches.";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }   

    IEnumerator PlayerAttack()
    {
        // Damage Enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            //If true, the battle will end
            state = BattleState.WON;
            EndBattle();
        }
        else 
        {
            //If false, enemy will have its turn
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + "attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            //If true, the battle will end
            state = BattleState.LOST;
            EndBattle();
        }
        else 
        {
            //If false, enemy will have its turn
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
            dialogueText text = "You won the battle!";
        else if (state == BattleState.LOST)
            dialoguetext text = "You were defeated";
    }   

    void PlayerTurn()
    {
        dialogue.text = "Choose an action:";
    }

    void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        
        StartCoroutine(PlayerAttack());
    }
}
