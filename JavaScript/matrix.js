//
// This is only a SKELETON file for the 'Matrix' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export class Matrix {
  constructor(input) {
    this.matrixString = input;
  }

  get rows() {
    return this.matrixString
      .split('\n')                      // e.g  '1 2\n3 4' => [ '1 2', '3 4' ]
      .map(row => row.split(' ')        // e.g. [ '1 2', '3 4' ] => [ [ '1', '2' ], [ '3', '4' ] ]
      .map(Number));                    // e.g. [ [ '1', '2' ], [ '3', '4' ] ] => [ [ 1, 2 ], [ 3, 4 ] ]
  }

  get columns() { 
    return this.rows[0]                                           // e.g '1 2\n3 4' => [ 1, 2 ]
      .map((column, index) => this.rows.map(row => row[index]));  // e.g.  [ 1, 2 ] => 1   0   and 2    1
                                                                  // e.g.  1 index 0 and 2 index 1 becomes [ [1, 3], [2, 4] ]
  }
}
