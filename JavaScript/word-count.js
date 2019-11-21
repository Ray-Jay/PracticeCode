import { arrayExpression } from "@babel/types";

export class Words {
  count(phrase) {
    // change input to lowercase, remove extra spaces & tabs, split on spaces into array
    let wordsArr = phrase.toLowerCase().trim().split(/\s+/);
    let resultObject = {};

    // for each word in array, check if key already exists in result. 
    // if so, update count. if not, add it to the result with a count of 1.
    wordsArr.forEach(element => {
      if (Object.keys(resultObject).indexOf(element) >= 0) {
        let currCount = resultObject[element];
        resultObject[element]= ++currCount;
      }
      else
      {
        resultObject[element] = 1;
      }
    });
    return resultObject;
  }
}