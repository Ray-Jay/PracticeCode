export const toRoman = (number) => {
  let result='';
  let decimals = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1];
  let romanNums = ['M', 'CM', 'D', 'CD', 'C', 'XC', 'L', 'XL', 'X', 'IX', 'V', 'IV', 'I'];
  
  for (let i = 0; i < decimals.length; i++) {
    while (number % decimals[i] < number) {
      result += romanNums[i];
      number -= decimals[i];
    }
  }
  return result;
};
