//
// This is only a SKELETON file for the 'Collatz Conjecture' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const steps = (number) => {
  if (number < 1) {
    throw new Error("Only positive numbers are allowed");
  }

  let numArray = [];

        // if number > 1, add it to the list, check if even or odd, apply appropriate formula 
        // to alter the number. keep going until you get to 1
        while (number > 1)
        {
            numArray.push(number);
            //number = condition     ?  yes      : no
            number = number % 2 == 0 ? number / 2: number * 3 + 1;
        }
        return numArray.length;
};
