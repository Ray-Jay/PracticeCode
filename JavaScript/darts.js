export const solve = (x, y) => {
  // x and y make up the legs of a triangle. by squaring them and taking the square root, you get the 
  // hypotenuse. if the hypotenuse is <= 10, they'll earn points.
  let hypotenuse = Math.sqrt(x**2 + y**2);
  return hypotenuse <= 1 ? 10 : hypotenuse <= 5 ? 5 : hypotenuse <= 10 ? 1 : 0 ;
};
