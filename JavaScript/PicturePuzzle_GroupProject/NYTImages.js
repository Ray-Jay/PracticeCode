'use strict';
//https://api.edamam.com/search?q=chicken&app_id=${YOUR_APP_ID}&app_key=${YOUR_APP_KEY}&from=0&to=3&calories=591-722&health=alcohol-free
let rangeEnd = 10;
let searchTerms = [ 'cruise', 'pitt', 'bullock','love','war','avengers','fincher','spielberg','samuel','wahlberg','wiig', 'scorsese','carey','keanu','dog','cat','bird'];

export default class NYTImages {
	constructor() {
		let urlRoot = 'https://api.nytimes.com/svc/movies/v2/reviews/search.json?query=';
		let keyPrefix = '&api-key=';
		let key = '1Y8VGljIMN1HyhZLRu0xXaThmkGsoGQu';
    let searchTerm1 = searchTerms[this.getRandomIndex(searchTerms.length)];
    console.log(searchTerm1);
		this.keyQuery = urlRoot + searchTerm1 + keyPrefix + key ;

		console.log(this.getRandomIndex(searchTerms.length));
	}

	getNYTImages() {
		
		let keyQuery = this.keyQuery;
		let randInd = this.getRandomIndex(rangeEnd);
		console.log(randInd);


		return new Promise(function(resolve, reject) {
			fetch(keyQuery)
				.then(function(result) {
					return result.json();
				})
				.then(function(json) {
          let nytInfo = json.results;
					console.log(nytInfo);
					while(!nytInfo[randInd] || !nytInfo[randInd].multimedia){
						randInd--;
						if(randInd<0){
							randInd=rangeEnd-1;
						}
					}
					console.log(randInd);
          let nytMulti = nytInfo[randInd].multimedia;
          let openDate = nytInfo[randInd].opening_date? nytInfo[randInd].opening_date: 'N/A';
					let nytArray = [nytMulti.src,nytInfo[randInd].display_title,openDate,nytInfo[randInd].headline, nytInfo[randInd].link.url];
					
					resolve(nytArray); 
				});
		});
	}

	getRandomIndex(arrLen) {
		return Math.floor(Math.random() * arrLen);
	}
}
