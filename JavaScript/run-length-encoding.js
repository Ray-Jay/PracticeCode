export const encode = (input) => {
  let currChar, prevChar = "", result = [];
  // for each character, check to see if equal to previous character. If so, update count of the letter
  // if not, add the the result with a count of 1
  for (let i = 0; i < input.length; i++) {
    currChar = input[i];
    if (currChar === prevChar) {
      result[result.length - 2]++;
    }
    else {  // new letter, add to result with count of 1

      result.push(1);
      result.push(input[i]);
      prevChar = input[i];
    }
  }
  // remove all individual 1's from array before turning into a string
  return result.map(el => el === 1 ? '' : el).join('');
};

export const decode = (input) => {
  let result = [], numArray = [];
  // for each character, check if number. If number, push to array to save. if not number, check for saved number
  // and print letter appropriate number of times.
  for (let i = 0; i < input.length; i++) {
    if (!isNaN(parseInt(input[i], 10))) {  // number. save to array
      numArray.push(input[i]);
    }
    else {  // letter. check to see if number was saved in array before it. If so, loop to add proper count of letter
      if (numArray.length > 0) {
        let count = numArray.map(Number).join('');
        for (let j = 0; j < count; j++) {
          result.push(input[i]);
        }
        numArray.length = 0;    // empty array after printing letter
      } else {  // no duplicates, add letter to output once
        result.push(input[i]);
      }
    }
  }
  return result.join('');
};