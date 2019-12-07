// create key exchange
export class DiffieHellman {
  constructor(p, g) {
    let isPrimeP = this.isPrime(p);
    let isPrimeG = this.isPrime(g);
    if ((!isPrimeP) || (!isPrimeG)) {
      throw new Error("Numbers must be prime");
    }
    this.p = p;
    this.g = g;
    // this.privateKeyA = this.setKey(p, 2);   // would be needed for real program
    // this.privateKeyB = this.setKey(p, 2);
  }
  
  getPublicKeyFromPrivateKey(privateKey) {
    if (privateKey < 2 || privateKey == this.p || privateKey > this.p) {
      throw new Error("Invalid private key value");
    }
    return Math.pow(this.g, privateKey) % this.p;
  }

  getSharedSecret(privateKey, publicKey) {
    return publicKey**privateKey % this.p;
  }

  // determines if number is prime number
  isPrime(number) {
    if (number < 2) { return false; }
    let isPrime = true;
    for (let i = 2; i <= Math.sqrt(number); i++) {
      if (number % i === 0) {
        isPrime = false;
      }
    }
    return isPrime;
  }
  // would be needed for real program
  // // generates random number between minimum and 1-less-than the number
  // setKey(number, minimum) {
  //   return Math.floor(Math.random() * (number - minimum) + minimum);
  // }
}