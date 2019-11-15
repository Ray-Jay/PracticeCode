//
// This is only a SKELETON file for the 'Pangram' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const isPangram = (input) => {
  // use regex to see if letter. if so, add to the Set. only distinct items will be added to set. 
  // finally, test the length of the set
  let distinctLetters = new Set();
  input = input.toLowerCase();

  [...input].forEach(ch => /[a-z]/.test(ch) ? distinctLetters.add(ch) : null );   // if not a character, do nothing
  return distinctLetters.size === 26;
};
