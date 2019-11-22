export class Anagram {
  constructor(word) {
    this.originalWord = word.toLowerCase();
    this.originalWordSorted = this.originalWord.split('').sort().join('');
  }

  matches(inputArr) {
    let result = [];
    let checkWord = '';
    let checkWordSorted = '';
    
    // for each word in array, sort it and compare to the original word
    inputArr.forEach(element => {
      checkWord = element.toLowerCase();
      checkWordSorted = checkWord.split('').sort().join('')
      if (checkWordSorted === this.originalWordSorted && this.originalWord !== checkWord) {
        result.push(element);
      }
    })
    return result;
  }
}