//
// This is only a SKELETON file for the 'RNA Transcription' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const toRna = (dna) => {
  let DNA = 'ACGT';
  let RNA = 'UGCA';
  let result = '';
  // take each letter in input string and use [...] to turn into array. find the index in DNA and add the same index
  // RNA to result string
  [...dna].forEach(letter => result += RNA[DNA.indexOf(letter)]);
  return result;
};
