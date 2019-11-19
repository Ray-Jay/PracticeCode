import { throwStatement } from "@babel/types";

//
// This is only a SKELETON file for the 'Triangle' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export class Triangle {
  constructor(side1, side2, side3) {
    this.side1 = side1;
    this.side2 = side2;
    this.side3 = side3;
  }

  kind() {
    let type;
    let anyEqual = this.side1 === this.side2 || this.side1 === this.side3 || this.side2 === this.side3;
    let allEqual = this.side1 === this.side2 ? this.side1 === this.side3 ? true : false : false;
    let triangleInequality = (this.side1 > 0 && this.side2 > 0 && this.side3 > 0)
      && (this.side1 + this.side2 >= this.side3)
      && (this.side1 + this.side3 >= this.side2)
      && (this.side2 + this.side3 >= this.side1);

    if (!triangleInequality) {
      throw new Error("Not a triangle");
    }
    
    if (!anyEqual && triangleInequality) {
      type = "scalene";
    }

    if (anyEqual && triangleInequality) {
      type = "isosceles";
    }

    if (allEqual && this.side1 !== 0) {
      type = "equilateral";
    }

    return type;
  }
}
