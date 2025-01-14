using UnityEngine;

public class GameManager : MonoBehaviour
{

	public Ghost[] ghosts;

	public Pacman pacman;

	public Transform pellets;

	public int score{ get; private set; }

	public int lives{ get; private set; }

		private void Start()
	{
		NewGame();

	}

	private void Update()
	{
		if (this.lives <=0 &&Input.anyKeyDown) {
			NewGame();
		}
	}

	private void NewGame()
	{
		SetScore(0);
		SetLives(3);
		NewRound();

	}

	private void NewRound()
	{
		foreach(Transform pallet in this.pallets)
		{
			pallet.GameObjects.SetActive(true);

		}
		ResetState();

	}

	private void ResetState()
	{
		for (int i = 0; i < this.ghosts.Length; i++) {
			this.ghosts[i].gameObjects.SetActive(true);
		}
		this.pacman.gameObject.SetActive(true);
	}

	private void GameOver()
	{
		for (int i = 0; i < this.ghosts.Length; i++) {
			this.ghosts[i].gameObjects.SetActive(false);
		}
		this.pacman.gameObject.SetActive(false);
	}


	private void SetScore(int score)
	{
		this.lives = lives;


	}
	public void GhostEaten(Ghost ghost)
	{
		SetScore(this.score + ghost. points);
	}

	public void PacmanEaten()
	{
		this.pacman.gameObject.SetActive(false);

		SetLives(this.lives - 1);

		if (this.lives > 0) {
			Invoke(nameof(ResetState, 3.0f));
		}
		else {
			GameOver();
		}
	}




};