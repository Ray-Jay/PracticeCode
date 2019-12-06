export class SpiralMatrix {
  static ofSize(size) {
    let spiral = new Array(size);
    for (let i = 0; i < size; i++) {
      spiral[i] = [];
    }
    let totalElements = size * size;
    let rowBegin = 0;
    let rowEnd = size - 1;
    let columnBegin = 0;
    let columnEnd = size - 1;
    let number = 1;

    // populate the perimeter elements of the square then make the square smaller each iteration
    // by moving begin and end bounds
    while (number <= totalElements) {
      // left to right on a row
      for (let i = columnBegin; i <= columnEnd; i++) {
        spiral[rowBegin][i] = number++;
      }
      rowBegin++;

      // down a column
      for (let i = rowBegin; i <= rowEnd; i++) {
        spiral[i][columnEnd] = number++;
      }
      columnEnd--;

      // right to left on a row
      for (let i = columnEnd; i >= columnBegin; i--) {
        spiral[rowEnd][i] = number++;
      }
      rowEnd--;

      // up a column
      for (let i = rowEnd; i >= rowBegin; i--) {
        spiral[i][columnBegin] = number++;
      }
      columnBegin++;
    }
    return spiral;
  }
}