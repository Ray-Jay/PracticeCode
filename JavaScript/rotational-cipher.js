export class RotationalCipher {
  static rotate(string, shiftKey) {
    if(shiftKey === 0) { return string }
    
    // checks if character code is a letter and which case
    let checkLetterAndCase = function (code) {
      if (code >= 65 && code < 91) {
        return [true, 'u'];
      }
      if (code >= 97 && code < 123) {
        return [true, 'l'];
      }
      return false;
    };
    
    // declare variables
    let charCode, newCode, newLetter, isLetter = [], output = [];

    // for each character in string, check if letter. if so, apply shift key, if not, add to output unchanged
    for (let i = 0; i < string.length; i++) {
      charCode = string.charCodeAt(i);
      isLetter = checkLetterAndCase(charCode);
      
      if (isLetter[0]) {
        newCode = charCode + shiftKey;
         // adjust character code if past letter bounds
        if (newCode > 90 && isLetter[1] === 'u'  ||  newCode > 122 && isLetter[1] === 'l') {
          newCode -= 26;
        }
        newLetter = String.fromCharCode(newCode);
        output.push(newLetter);
      }
      else {  // not a letter, remains the same.
        output.push(string[i]);
      }
    }

    
    return output.join('');
  }
}