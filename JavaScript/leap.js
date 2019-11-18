//
// This is only a SKELETON file for the 'Leap' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const isLeap = (year) => {
  let divBy4 = year % 4 == 0;
  let divBy100 = year % 100 == 0;
  let divBy400 = year % 400 == 0;

  return (divBy4 && !divBy100 && !divBy400) || (divBy4 && divBy400);
};
