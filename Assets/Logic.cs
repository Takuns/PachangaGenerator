using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public Image[] players;
    public List<Image> invitados = new List<Image>();

    public GameObject playerPrefab;
    public Transform invitadosParent;

    public GameObject remove1;
    public GameObject remove2;

    private int playersByTeam = 8;

    public void Generate()
    {
        int team1 = 0;
        int team2 = 0;
        int albitro = 0;

        for (int i = 0; i < playersByTeam * 2 + 1; i++)
        {
            Image player = players[i];
            bool other = false;
            do
            {
                other = false;
                int temp = Random.Range(0, 3);
                switch (temp)
                {
                    case 0:
                        if (team1 < playersByTeam)
                        {
                            team1++;
                            var tempColor = player.color;
                            tempColor = new Color(255f / 255f, 69f / 255f, 0);//orange
                            player.color = tempColor;
                        }
                        else
                        {
                            other = true;
                        }
                        break;

                    case 1:
                        if (team2 < playersByTeam)
                        {
                            team2++;
                            var tempColor = player.color;
                            tempColor = Color.blue;
                            player.color = tempColor;
                        }
                        else
                        {
                            other = true;
                        }
                        break;

                    case 2:
                        if (albitro < 1)
                        {
                            albitro++;
                            var tempColor = player.color;
                            tempColor = Color.black;
                            player.color = tempColor;
                        }
                        else
                        {
                            other = true;
                        }
                        break;
                }
                if (albitro == 1 && team1 == playersByTeam && team2 == playersByTeam)
                    other = false;
            } while (other);
        }
    }

    public bool randomBoolean()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }

    public void Vs8()
    {
        playersByTeam = 8;
        remove1.SetActive(true);
        remove2.SetActive(true);
        Reiniciar();
    }

    public void Vs7()
    {
        playersByTeam = 7;
        remove1.SetActive(false);
        remove2.SetActive(false);
        Reiniciar();
    }

    public void Reiniciar()
    {
        foreach (var player in players)
        {
            var tempColor = player.color;
            tempColor = Color.white;
            player.color = tempColor;
        }
    }

    public void AddInvitado()
    {
        GameObject temp = Instantiate(playerPrefab, invitadosParent);
        invitados.Add(temp.GetComponentInChildren<Image>());
    }

    public void RemoveInvitado()
    {
        GameObject temp = invitados[invitados.Count - 1].transform.parent.gameObject;
        invitados.RemoveAt(invitados.Count - 1);
        Destroy(temp);
    }
}