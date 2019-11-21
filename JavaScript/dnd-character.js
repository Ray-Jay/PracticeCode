export const abilityModifier = (value) => {
  if (value < 3) {
    throw new Error('Ability scores must be at least 3');
  }
  if (value > 18) {
    throw new Error('Ability scores can be at most 18');
  }
  return Math.floor((value - 10) / 2);
};

export class Character {

  constructor() {
    this.setStrength = Character.rollAbility();
    this.setDexterity = Character.rollAbility();
    this.setConstitution = Character.rollAbility();
    this.setIntelligence = Character.rollAbility();
    this.setWisdom = Character.rollAbility();
    this.setCharisma = Character.rollAbility();
    this.setHitpoints = abilityModifier(this.constitution) + 10;
  }

  static rollAbility() {
    function rollDie() {
      return Math.floor(Math.random() * 6 + 1);
    }

    // create array with 4 dice and roll each one. find the minimum and return the sum - minimum
    let diceArr = [rollDie(), rollDie(), rollDie(), rollDie()];
    let minimum = Math.min(...diceArr);
    return diceArr.reduce((acc, curr) => acc + curr) - minimum;
  }

  get strength() {
    return this.setStrength;
  }

  get dexterity() {
    return this.setDexterity;
  }

  get constitution() {
    return this.setConstitution;
  }

  get intelligence() {
    return this.setIntelligence;
  }

  get wisdom() {
    return this.setWisdom;
  }

  get charisma() {
    return this.setCharisma;
  }

  get hitpoints() {
    return this.setHitpoints;
  }
}
