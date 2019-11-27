export const matchingBrackets = (brackets) => {
  let stack = [];
  let validOpen = ['{', '(', '['];
  let validClose = ['}', ')', ']'];
  let openBracket;
  let openIndex;
  let closeIndex;

  // **: can't use [...brackets] spread operator because need to break out of loop if not matching. So used, for...of
  for (const bracket of brackets) {
    // if open symbol, push onto stack
    if (validOpen.includes(bracket)) {
      stack.push(bracket);
    }
    // if close symbol, pop an item from the stack and compare index postions of valid values. 
    // If not the same, return false.
    if (validClose.includes(bracket)) {
      openBracket = stack.pop();
      openIndex = validOpen.indexOf(openBracket);
      closeIndex = validClose.indexOf(bracket);

      if (openIndex !== closeIndex) {
        return false;
      }
    }
  }

  // once all brackets processed, check if stack is empty. if not, will return false
  return stack.length === 0;
};
