export const validate = (number) => {
  const numberAsString = number.toString();
  const length = numberAsString.length;
  let sum = 0;
  [...numberAsString].forEach(digit => sum += Number(digit) ** length);
  return sum === number;
};
