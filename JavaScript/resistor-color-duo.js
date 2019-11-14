//
// This is only a SKELETON file for the 'Resistor Color Duo' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const value = (array) => {
  let result = "";
  for (let index = 0; index < 2; index++) {
    result += COLORS.indexOf(array[index]);
  }
  return parseInt(result, 10);
};

const COLORS = ["black","brown","red","orange","yellow","green","blue","violet","grey","white"]
