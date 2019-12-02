export class Series {
  constructor(input) {
    this._digits = Array.from(input, Number);
  }

  get digits() {
    return this._digits;
  }

  slices(sliceLength) {
    if (sliceLength > this._digits.length) {
      throw new Error('Slice size is too big.');
    }
    let result = [];
    // maximum number of subsequences = string.length - slicelength + 1
    // https://stackoverflow.com/questions/8466861/all-subsequences-of-a-string-of-length-n
    let maxNumOfSequences = this._digits.length - sliceLength + 1

      for (let seqNum = 0; seqNum < maxNumOfSequences; seqNum++) {
        let sequence = [];
        for (let i = seqNum; i < seqNum + sliceLength; i++) {
          sequence.push(this._digits[i]);
        } 
        result.push(sequence);
      }

    return result;
  }
}
