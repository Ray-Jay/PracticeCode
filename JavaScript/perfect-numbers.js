export const classify = (value) => {
  if (value < 1) {
    throw new Error("Classification is only possible for natural numbers.");
  }
  if (value === 1) {
    return 'deficient';
  }

  // create new array with values from 1 to (value - 1)
  // filter the array to contain only factors of the value
  // add up the values
  let aliquotSum = Array.from(new Array(value - 1),(x, i) => i + 1)
                        .filter(x => value % x == 0)
                        .reduce((accumulator, currentValue) => accumulator + currentValue);
  return aliquotSum === value ? 'perfect' : aliquotSum < value ? 'deficient' : 'abundant';
};
