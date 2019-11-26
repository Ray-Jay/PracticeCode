export const parse = (phrase) => {
  let result = '';
  let words = phrase.split(' ');

  // if word has - or _, proceed to special processing. otherwise, add first letter to result
  words.forEach(word => {
    if (word.indexOf('-') >= 0 || word.indexOf('_') >= 0) {
      checkSpecialCharacters(word);
    }
    else {
      result += word[0].toUpperCase();
    }
  })

  // checks words with - and _ to see if need to add to result
  function checkSpecialCharacters(word) {
    let hasDash = word.indexOf('-') >= 0;
    let hasUnderscore = word.indexOf('_') >= 0;
    let moreWords = [];

    if (hasDash && word.length > 1) {
      moreWords = word.split('-').filter(element => element.length > 0);
      result += moreWords[0][0].toUpperCase();   // first element, first position
      result += moreWords[1][0].toUpperCase();   // second element, first position
    }

    if (hasUnderscore && word.length > 1) {
      moreWords = word.split('_').filter(element => element.length > 0);
      result += moreWords[0][0].toUpperCase();
    }
  }

  return result;
};

