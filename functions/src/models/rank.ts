/**
 * Class for Rank.
 */
export class Rank {
  name: string;
  days: number;
  wealth: number;

  /**
   * Constructor for Rank object.
   * @param {string} name Name of the rank uploader.Either the user's Steam name or the default "Player".
   * @param {number} days Number of days passed in the game.
   * @param {number} wealth Amount of wealth accumulated in the game.
   */
  constructor (name: string, days: number, wealth: number) {
    this.name = name;
    this.days = days;
    this.wealth = wealth;
  }
}
