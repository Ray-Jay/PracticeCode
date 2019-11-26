export const isIsogram = (word) => {
  word = word.toLowerCase();

  // find first and last index of the current letter. if they don't match, there are duplicates
  for (let char of word) {
    if (/[a-z]/.test(char) && (word.indexOf(char) !== word.lastIndexOf(char))) {
      return false;
    }
  }
  return true;
};
