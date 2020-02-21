'use strict';

export default class NasaInfo {
	constructor() {
		let imgCount = '&count=1';
		let keyPrefix = '?api_key=';
		let key = 'kfdKTVlNYxldY5TBdwCW5WWGqjMKEvUIdelvpm0k';
		let urlRoot = 'https://api.nasa.gov/planetary/apod';
		this.keyQuery = urlRoot + keyPrefix + key + imgCount;
	}

	getNasaImage() {
    let nasaImg;
    let imgDate;
    let imgExplain;
    let imgTitle;
    let keyQuery = this.keyQuery;
    //console.log('callNasa triggered!');
    
    return(new Promise(function(resolve,reject){

      fetch(keyQuery)
        .then(function(result) {
          return result.json();
        })
        .then(function(json) {
          //console.log(json[0].hdurl);
          nasaImg = json[0].hdurl;
          imgTitle = json[0].title;
          imgDate = json[0].date; //string: date photo was posted
          imgExplain = json[0].explanation; // string: explanation of image
          
          //console.log(`${nasaImg}`)
          resolve([nasaImg, imgDate, imgExplain,imgTitle]); //nasaImg is a string of the image url
        });
    }));
	}
}
