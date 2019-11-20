//
// This is only a SKELETON file for the 'Raindrops' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const convert = (number) => {
  let factor3 = number % 3 == 0;
  let factor5 = number % 5 == 0;
  let factor7 = number % 7 == 0;
  let factor357 = factor3 || factor5 || factor7;
  let result = '';

  if (factor3) {
    result += 'Pling';
  }
  if (factor5) {
    result += 'Plang';
  }
  if (factor7) {
    result += 'Plong';
  }
  if (!factor357) {
    result += number;
  }
  return result;
};
