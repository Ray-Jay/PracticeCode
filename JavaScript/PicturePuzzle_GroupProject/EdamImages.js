'use strict';
//https://api.edamam.com/search?q=chicken&app_id=${YOUR_APP_ID}&app_key=${YOUR_APP_KEY}&from=0&to=3&calories=591-722&health=alcohol-free
let rangeStart = 0;
let rangeEnd = 100;
let mainIngredient = [ 'chicken', 'beef', 'shrimp', 'lamb', 'broccoli','tofu','lobster' ];
export default class EdamImages {
	constructor() {
		let urlRoot = ' https://api.edamam.com/search';
		//let temp = mainIngredient[this.getRandomIndex(mainIngredient.length)];
		console.log(this.getRandomIndex(mainIngredient.length));
		let searchPrefix = '?q=' + mainIngredient[this.getRandomIndex(mainIngredient.length)];
		let appID_prefix = '&app_id=';
		let edamID = '436465a8';
		let imgCount = '&count=1';
		let keyPrefix = '&app_key=';

		let key = 'c91886c3f047cc08c3121563b3ae6ce8';
		let rangePrefix = '&from=' + rangeStart + '&to=' + rangeEnd;
		this.keyQuery = urlRoot + searchPrefix + appID_prefix + edamID + keyPrefix + key + rangePrefix;
	}

	getEdamImages() {
		
		let keyQuery = this.keyQuery;
		let randInd = this.getRandomIndex(rangeEnd);

		return new Promise(function(resolve, reject) {
			fetch(keyQuery)
				.then(function(result) {
					return result.json();
				})
				.then(function(json) {
          let edamImg = json.hits[randInd];
          let edamArray = [edamImg.recipe.image,edamImg.recipe.label,edamImg.recipe.calories, edamImg.recipe.ingredientLines, edamImg.recipe.url];
          console.log(edamImg);
					
					resolve(edamArray); 
				});
		});
	}

	getRandomIndex(arrLen) {
		return Math.floor(Math.random() * arrLen);
	}
}
