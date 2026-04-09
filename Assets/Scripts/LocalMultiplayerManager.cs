using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayerManager : MonoBehaviour
{
    public List<Sprite> playerSprites;
    public List<PlayerInput> players;

    public void OnPlayerJoin(PlayerInput player)
    {
        players.Add(player);
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = playerSprites[player.playerIndex];

        LocalMulitplayerController controller = player.GetComponent<LocalMulitplayerController>();
        controller.manager = this;
    }

    public void playerAttacking(PlayerInput attackingPlayer)
    {
        for(int i = 0; i < players.Count; i++)
        {
            if(attackingPlayer == players[i]) continue;
            
            if(Vector2.Distance(attackingPlayer.transform.position, players[i].transform.position) < 0.5f)
            {
                Debug.Log("Player " + attackingPlayer.playerIndex + " hit player " + players[i].playerIndex);
            }
        }
    }
}
