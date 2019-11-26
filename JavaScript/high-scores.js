//
// This is only a SKELETON file for the 'High-Scores' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export class HighScores {
  constructor(highScores) {
    this.highScores = highScores;
  }

  get scores() {
    return this.highScores;
  }

  get latest() {
    return this.highScores[this.highScores.length - 1];
  }

  get personalBest() {
    return Math.max(...this.highScores);
  }

  get personalTopThree() {
    // the sort is in descending order. then, up to 3 items are returned
    return this.highScores.sort((a, b) => b - a).slice(0, 3);
  }
}
