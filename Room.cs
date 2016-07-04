using UnityEngine;
using System.Collections.Generic;
using System;

public class Room {

	float startTime;
	float creationTime; // is that the time in GMT? what happens for users in different locations. Get the time from the server
	int totalRounds;
	int currentRound;
	int maxPlayers;

	List<Player> players;

	public Room (int totalRounds, int maxPlayers, Player player, float creationTime) {
		this.totalRounds = totalRounds;
		this.maxPlayers = maxPlayers;
		this.players.Add(player);
		this.creationTime = creationTime;
		currentRound = 0;
	}

}

