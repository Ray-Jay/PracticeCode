export class Squares {
  constructor(max) {
    this.maxNumber = max;
  }

  get sumOfSquares() {
    // fill numbers array from 1 to the max number (where x is the number and y is the index)
    // then squares each number in a new array
    // finally reduces the array to one value using addition
    let numbersArr = Array(this.maxNumber).fill(1).map((x, y) => x + y);
    let sum = numbersArr.map(n => n * n).reduce((accumulator, currentValue) => accumulator + currentValue);
    return sum;

    // this could all be done in one line like this
    // return Array(this.maxNumber).fill(1).map((x, y) => x + y).map(n => n * n).reduce((accumulator, currentValue) => accumulator + currentValue);
  }

  // algorithm to sum numbers from 1 to the max number, then square it
  get squareOfSum() {
    return  Math.pow(this.maxNumber * (1 + this.maxNumber) / 2, 2);
  }

  get difference() {
    return this.squareOfSum - this.sumOfSquares;
  }
}
