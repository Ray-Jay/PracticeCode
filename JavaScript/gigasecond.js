//
// This is only a SKELETON file for the 'Gigasecond' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const gigasecond = (moment) => {
  // Universal Time Coordinated (UTC)
  // had to hange 1,000,000,000 SECONDS to MILLISECONDS by multiplying by 1000 (or using 10^12)
  return new Date(moment.getTime() + Math.pow(10, 12));
};
