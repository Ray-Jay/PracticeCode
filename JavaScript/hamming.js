export const compute = (strand1, strand2) => {
  let isEmptyStrand1 = strand1.length === 0;
  let isEmptyStrand2 = strand2.length === 0;
  let counter = 0;

  if (isEmptyStrand1 && !isEmptyStrand2) {
    throw new Error("left strand must not be empty");
  }
  if (isEmptyStrand2 && !isEmptyStrand1) {
    throw new Error("right strand must not be empty");
  }
  if (strand1.length !== strand2.length) {
    throw new Error("left and right strands must be of equal length");
  }

  for (let i = 0; i < strand1.length; i++) {
    strand1[i] !== strand2[i] ? counter++ : counter += 0;
  }
  return counter;
};
