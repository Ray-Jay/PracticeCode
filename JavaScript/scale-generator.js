export class Scale {
  constructor(tonic) {
    this.tonic = tonic;
  }

  chromatic() {
    let flats = ['F', 'Bb', 'Eb', 'Ab', 'Db', 'Gb', 'd', 'g', 'c', 'f', 'bb', 'eb'];
    let sharpsScale = ['A', 'A#', 'B', 'C', 'C#', 'D', 'D#', 'E', 'F', 'F#', 'G', 'G#'];
    let flatsScale = ['A', 'Bb', 'B', 'C', 'Db', 'D', 'Eb', 'E', 'F', 'Gb', 'G', 'Ab'];

    // determines if tonic is flat or not. converts first character to uppercase. 
    // finally, gets index of tonic in correct scale
    let isFlat = flats.includes(this.tonic);
    this.tonic = this.tonic.replace(this.tonic[0], this.tonic[0].toUpperCase());
    let index = isFlat ? flatsScale.indexOf(this.tonic) : sharpsScale.indexOf(this.tonic);


    return isFlat ? flatsScale.slice(index).concat(flatsScale.slice(0, index))
                  : sharpsScale.slice(index).concat(sharpsScale.slice(0, index));

    // the above is doing the same as this:
    // creates arrays from tonic to end, and from front of array to 1 before tonic and concatenates them
    // let fromTonic = [];
    // let wrapAround = [];
    // if (isFlat) {
    //   fromTonic = flatsScale.slice(index);
    //   wrapAround = flatsScale.slice(0, index);
    // } else {
    //   fromTonic = sharpsScale.slice(index);
    //   wrapAround = sharpsScale.slice(0, index);
    // }
    // return fromTonic.concat(wrapAround);
  }

  interval(intervals) {
    let chromaticScale = this.chromatic();
    let index = 0;
    let scale = [];

    // for each character in interval, print the index position, then increment the index for the next print
    [...intervals].forEach(interval => {
      scale.push(chromaticScale[index]);
      interval === 'm' ? index++ :
        interval === 'M' ? index += 2
          : index += 3;   // this is for 'A'
    });
    return scale;
  }
}