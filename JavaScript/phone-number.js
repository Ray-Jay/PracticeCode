export class PhoneNumber {
  constructor(inputNumber) {
    this.inputNumber = inputNumber;
  }

  number() {
    // for each character in input, filter out numbers only and return a string
    let phoneNumber = [...this.inputNumber].filter(char => !isNaN(char) && char !== ' ').join('');

    // return null if phone number matches any of these conditions
    if (phoneNumber.length > 11
      || phoneNumber.length < 10
      || (phoneNumber.length === 11 && phoneNumber[0] != 1)) {
      return null;
    }

    // if 11-digit number, remove country code
    if (phoneNumber.length === 11) {
      phoneNumber = phoneNumber.slice(1);
    }

    // if area code (at index 0) or exchange code (at index 3) are less than 2, return null
    if (phoneNumber[0] < 2 || phoneNumber[3] < 2) {
      return null;
    }

    return phoneNumber;
  }
}