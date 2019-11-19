import { valueToNode, cloneWithoutLoc } from "@babel/types";

export const transform = (object) => {
  let transformed = {};

  // for ... in iterates over properties of an object
  for (let property in object) {   
    let pointValue = property;
    let lettersArray = object[property];

     // add each letter in array to new object with given point value
    for (let index = 0; index < lettersArray.length; index++) {  
      transformed[lettersArray[index].toLowerCase()] = Number(pointValue);
    }
  }
  return transformed;
};
