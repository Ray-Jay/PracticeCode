export const transpose = (inputArray) => {
  // define array to hold output. if the input is empty, return empty array
  let transposedArr = [];
  if (inputArray.length === 0) return transposedArr;

  // find longest row in input array and use that to determine the number of columns of transposed array
  let numberOfColumns = Math.max(...(inputArray.map(el => el.length)));

  // for each # of columns, put a temporary array in the output array to group data
  for (let i = 0; i < numberOfColumns; i++) {
    transposedArr.push([]);
  }

  // iterate over each row of input, and place into correct column array in output. if undefined, put a space
  for (let i = 0; i < inputArray.length; i++) {
    for (let j = 0; j < numberOfColumns; j++) {
      transposedArr[j].push(inputArray[i][j] || ' ');
    }
  }

  // join each column array into a string for final version
  for (let i = 0; i < transposedArr.length; i++) {
    transposedArr[i] = transposedArr[i].join('');
  }

  // check the very last element to remove any whitespace
  transposedArr[transposedArr.length - 1] = transposedArr[transposedArr.length - 1].trimRight();

  return transposedArr;
};
