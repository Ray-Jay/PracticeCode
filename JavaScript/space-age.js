//
// This is only a SKELETON file for the 'Space Age' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const age = (planet, seconds) => {
  let earthAgeInYears = seconds / 31557600.0; // 31557600 = 365.25 earth year * 24 hrs * 60 min * 60 sec
  let age;

  switch (planet) {
    case 'earth':
      age = Math.round(earthAgeInYears * 100) / 100;
      break;
    case 'mercury':
      age = Math.round(earthAgeInYears / 0.2408467 * 100) / 100;
      break;
    case 'venus':
      age = Math.round(earthAgeInYears / 0.61519726 * 100) / 100;
      break;
    case 'mars':
      age = Math.round(earthAgeInYears / 1.8808158 * 100) / 100;
      break;
    case 'jupiter':
      age = Math.round(earthAgeInYears / 11.862615 * 100) / 100;
      break;
    case 'saturn':
      age = Math.round(earthAgeInYears / 29.447498 * 100) / 100;
      break;
    case 'uranus':
      age = Math.round(earthAgeInYears / 84.016846 * 100) / 100;
      break;
    case 'neptune':
      age = Math.round(earthAgeInYears / 164.79132 * 100) / 100;
      break;
  }
  return age;
};
