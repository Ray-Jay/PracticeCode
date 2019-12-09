export const hey = (message = '') => {
  let isEmpty, isQuestion, isAllCaps, lettersOnly, result, trimmed, response = "", types = [];
  trimmed = message.trim();

  // determine what type of message
  isEmpty = trimmed.length === 0;
  isQuestion = !isEmpty ? trimmed[trimmed.length - 1] === '?' : false;      // last char is ?
  lettersOnly = !isEmpty ? trimmed.match(/[a-zA-Z]/g) : '';                 // filters only letters. if input is numbers only produces null
  lettersOnly = lettersOnly != null && lettersOnly.length > 0 ? lettersOnly.join('') : '';    // if not null or empty, join as string
  isAllCaps = lettersOnly.length > 0 && lettersOnly === lettersOnly.toUpperCase();  // determines if has letters and all uppercase

  // types [empty, question, caps, all, initial state]
  types = [1, 2, 4, 7, 0];

  // uses bitwise | operator to turn on bits for appropriate message type
  let messageAttributes = types[4];
  isEmpty ? messageAttributes |= types[0] : null;      // if empty, turn on empty field, else do nothing
  isQuestion ? messageAttributes |= types[1] : null;   // if question, turn on question field, else do nothing
  isAllCaps ? messageAttributes |= types[2] : null;    // if all caps, turn on all caps field, else do nothing

  // uses bitwise & operator to compare each position to see what is a 1
  result = types[3] & messageAttributes;
  switch (result) {
    case 1:
      response = "Fine. Be that way!";
      break;
    case 2:
      response = "Sure.";
      break;
    case 4:
      response = "Whoa, chill out!";
      break;
    case 6:
      response = "Calm down, I know what I'm doing!";
      break;
    default:
      response = "Whatever.";
      break;
  }
  return response;
};