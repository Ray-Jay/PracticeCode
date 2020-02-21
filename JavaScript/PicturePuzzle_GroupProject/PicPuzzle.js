'use strict';
import NasaInfo from './NasaInfo.js';
import EdamImages from './EdamImages.js';
import NYTImages from './NYTImages.js';

let form;
let puzzleSolved;

let difficulty, category; //difficulty & category variables hold the user-selected puzzle difficulty and picture category.

let canvas1;
let ctx1;
let sourceImg;

let iWidth; // variable for image width
let iHeight; // variable for image height
let oWidth;
let oHeight;

let tileDivisor; // image to be divided into tileDivisor*tileDivisor sections
let tileDimArrayScaled; // array of scaled tile dimensions, [ width,  height]
let tileDimArray0; // array of original tile dimensions, [ width,  height]
let tilePosArray0 = [];

// variables for swapping tiles
let tileCurrentlySelected;
let tileTint = '#7dee61';
let tile1Index;
let tile2Index;

// variables for scoring
let swapCount;
let score;
let scoreDisplay = document.getElementById('score');

//variable for movie category.
let nytImgUrl;
let nytImgTitle;
let nytImgDate;
let nytImgHeadline;
let nytImgReviewUrl;

// variables for food category
let edamImgUrl;
let edamRecipeLabel;
let edamRecipeCalories;
let edamRecipeIngredients;
let edamRecipeUrl;

// variables for space category
let nasaImgUrl;
let nasaImgTitle;
let nasaImgExplanation;
let nasaImgDate;

// variables for audio control
let puzzleSound = document.querySelector('#puzzleSound');
let winSound = document.querySelector('#winSound');
let loseSound = document.querySelector('#loseSound');

let body = document.querySelector('body');
body.onload = initialize;

// initialize items on page load
function initialize() {
	form = document.getElementById('form');
	form.addEventListener('submit', validateButton, false);
	tileCurrentlySelected = false;
	swapCount = 0;
	score = 0;
}

// determine selections for difficulty and category, then get an image
function validateButton(e) {
	let difficulties = document.getElementsByName('difficulty');
	let categories = document.getElementsByName('category');
	difficulty = [ ...difficulties ].filter((p) => p.checked)[0].value;
	category = [ ...categories ].filter((p) => p.checked)[0].value;

	e.preventDefault();
	setImage();
}

// set size of image and populat source. Async required to wait for image retrieval
async function setImage() {
	sourceImg = new Image(420 * 2, 300 * 2);

	introScreen.style.display = 'none';
	puzzle.style.display = 'flex';

	sourceImg.src = await assignImage(category);
	sourceImg.addEventListener('load', setCanvas, false);
}

// connect to API to get NASA image
async function getNasaImg() {
	let nasaObj = new NasaInfo();
	let nasaImgInfo = await nasaObj.getNasaImage();
	return nasaImgInfo;
}

// connect to API to get Food image
async function getEdamImg() {
	let edamObj = new EdamImages();
	let edamImgInfo = await edamObj.getEdamImages();
	return edamImgInfo;
}

// connect to API to get Movie image
async function getNytImg() {
	let nytObj = new NYTImages();
	let nytImgInfo = await nytObj.getNYTImages();
	return nytImgInfo;
}

// assign an image based on the user category selection. Async required to wait for image retrieval
async function assignImage(categoryPick) {
	let temp;
	switch (categoryPick) {
		case 'food':
			// return 'https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.nationaltrust.org.uk%2Fimages%2F1431747858549-stourhead-autumn-nov-2013-2.jpg&f=1&nofb=1';
			temp = await getEdamImg();
			edamImgUrl = temp[0];
			edamRecipeLabel = temp[1];
			edamRecipeCalories = temp[2];
			edamRecipeIngredients = temp[3];
			edamRecipeUrl = temp[4];
			return edamImgUrl;
			break;
		case 'movies':
			// return 'https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn3.movieweb.com%2Fi%2Farticle%2FOsq3U5y34HTQpCBbV0DlZ3p7CSwyqj%2F1200%3A100%2FAvengers-Endgame-Posters.jpg&f=1&nofb=1';
			temp = await getNytImg();
			nytImgUrl = temp[0];
			nytImgTitle = temp[1];
			nytImgDate = temp[2];
			nytImgHeadline = temp[3];
			nytImgReviewUrl = temp[4];
			return nytImgUrl;
			break;
		// case 'space':
		// 	return 'https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fapod.nasa.gov%2Fapod%2Fimage%2F1705%2FArp273Main_HubblePestana_1080.jpg&f=1&nofb=1';
		// 	break;
		case 'space':
			temp = await getNasaImg();
			nasaImgUrl = temp[0];
			nasaImgDate = temp[1];
			nasaImgExplanation = temp[2];
			nasaImgTitle = temp[3];
			console.log(nasaImgUrl);
			return nasaImgUrl;
			break;
	}
}

function removeLoadingVid(){
	
	document.querySelector('#puzzle').removeChild(document.querySelector('#loading'));
}

function showHurryGif(){
	document.querySelector('#hurry').style.display = 'block';
}

function showLoseGif(){
	document.querySelector('#hurry').remove();
	document.querySelector('#lose').style.display = 'block';
}

// define canvas dimensions, use image width/height to determine scale
function setCanvas() {
	showHurryGif();
	removeLoadingVid();
	puzzleSound.play();
	canvas1 = document.getElementById('canvas1');
	ctx1 = canvas1.getContext('2d');

	oWidth = sourceImg.naturalWidth;
	oHeight = sourceImg.naturalHeight;
	iWidth = sourceImg.width;
	iHeight = sourceImg.height;

	tileDivisor = difficulty;
	tileDimArrayScaled = [ Math.floor(iWidth / tileDivisor), Math.floor(iHeight / tileDivisor) ];
	tileDimArray0 = [ Math.floor(oWidth / tileDivisor), Math.floor(oHeight / tileDivisor) ];

	canvas1.width = iWidth;
	canvas1.height = iHeight;
	canvas1.style.border = '1px solid red';
	buildArray();
	reTileImage();
	//document.addEventListener('mousemove', debugVals);
}

// populate array with x/y coordinates for each image slice. each object holds original, scaled, and shuffled coordinates
function buildArray() {
	tilePosArray0 = [];

	for (let k = 0; k < difficulty; k++) {
		//console.log(`k:${k}`); //**For Debug */
		for (let m = 0; m < difficulty; m++) {
			//console.log(`m:${m}`); //**For Debug */
			tilePosArray0[k * difficulty + m] = {
				x0: m * tileDimArray0[0],
				y0: k * tileDimArray0[1],
				xCanvasPosProper: m * tileDimArrayScaled[0],
				yCanvasPosProper: k * tileDimArrayScaled[1],
				xCanvasPosPresent: 0,
				yCanvasPosPresent: 0
			};
			//console.log(tilePosArray0[k * difficulty + m]); //**For Debug */
		}
	}
}

// slice the image, scale it to size and draw. Update coordinates of slice as placed and show puzzle
function reTileImage(e) {
	let tempArr = shuffle(tilePosArray0.length);
	for (let k = 0; k < tilePosArray0.length; k++) {
		ctx1.drawImage(
			sourceImg,
			tilePosArray0[k].x0,
			tilePosArray0[k].y0,
			...tileDimArray0,
			tilePosArray0[tempArr[k]].xCanvasPosProper,
			tilePosArray0[tempArr[k]].yCanvasPosProper,
			...tileDimArrayScaled
		);
		tilePosArray0[k].xCanvasPosPresent = tilePosArray0[tempArr[k]].xCanvasPosProper;
		tilePosArray0[k].yCanvasPosPresent = tilePosArray0[tempArr[k]].yCanvasPosProper;
	}
	// display timer
	let difficultyAsNumber = Number(difficulty);
	let seconds = difficultyAsNumber === 5 ? 135 : difficultyAsNumber === 4 ? 90 : 45;
	countDown(seconds); 
	// display score
	scoreDisplay.innerHTML = `Score: ${score}`;

	canvas1.addEventListener('mousedown', getCursorPos);
}

// returns array of shuffled indexes for the size of the puzzle
function shuffle(number) {
	let array = [];
	for (let i = 0; i < number; i++) {
		array.push(i);
	}
	let currentIndex = array.length,
		temporaryValue,
		randomIndex;

	while (0 !== currentIndex) {
		randomIndex = Math.floor(Math.random() * currentIndex);
		currentIndex -= 1;
		temporaryValue = array[currentIndex];
		array[currentIndex] = array[randomIndex];
		array[randomIndex] = temporaryValue;
	}
	return array.slice(); // return a new array containing values in random order.
}

// displays timer to user
function countDown(seconds) {
	if (!puzzleSolved) {
		let element, timer;
		element = document.getElementById('timeDisplay');
		element.style.color = seconds < 10 ? 'Red' : 'White';
		element.innerHTML = `Time Left: ${seconds} seconds`;

		if (seconds < 1) {
			clearTimeout(timer);
			element.innerHTML = "Time's Up!";
			showLoseGif();
			displayEndScreen('You Lose!');
		} else {
			seconds--;
			timer = setTimeout(countDown, 1000, seconds);
		}
	}
}

// determines x/y coordinates of mouse in the canvas, based on location when clicked
function getCursorPos(eventA) {
	const rectangle = canvas1.getBoundingClientRect();
	const x = Math.floor(eventA.clientX - rectangle.left);
	const y = Math.floor(eventA.clientY - rectangle.top);
	// console.log(`Canvas X: ${x}  Canvas Y: ${y}`);

	selectTile(x, y);
}

// determines what tile has been selected on the puzzle using coordinates
function selectTile(mouseX, mouseY) {
	if (mouseX >= 0 && mouseX <= iWidth && mouseY >= 0 && mouseY <= iHeight) {
		let tile;
		let offsetX = tileDimArrayScaled[0];
		let offsetY = tileDimArrayScaled[1];

		for (let index = 0; index < tilePosArray0.length; index++) {
			tile = tilePosArray0[index];
			if (
				mouseX >= tile.xCanvasPosPresent &&
				mouseX < tile.xCanvasPosPresent + offsetX &&
				mouseY >= tile.yCanvasPosPresent &&
				mouseY < tile.yCanvasPosPresent + offsetY
			) {
				if (!tileCurrentlySelected) {
					tile1Index = index;
					markSelectedTile(index);
				} else {
					tile2Index = index;
					markSelectedTile(index); //Arbitrarily highlight tilePosArray0[2]
					setTimeout(swapTiles, 500);
					swapCount++;
				}
			}
		}
	}
}

// highlight tiles selected for swap
function markSelectedTile(index) {
	ctx1.save();
	ctx1.globalAlpha = 0.4;
	ctx1.fillStyle = tileTint;
	ctx1.fillRect(
		tilePosArray0[index].xCanvasPosPresent,
		tilePosArray0[index].yCanvasPosPresent,
		...tileDimArrayScaled
	);
	ctx1.restore();
	tileCurrentlySelected = !tileCurrentlySelected;
}

// when two tiles are selected, switch positions, update score, and check for win
function swapTiles() {
	let tempX = tilePosArray0[tile2Index].xCanvasPosPresent;
	let tempY = tilePosArray0[tile2Index].yCanvasPosPresent;
	tilePosArray0[tile2Index].xCanvasPosPresent = tilePosArray0[tile1Index].xCanvasPosPresent;
	tilePosArray0[tile2Index].yCanvasPosPresent = tilePosArray0[tile1Index].yCanvasPosPresent;
	tilePosArray0[tile1Index].xCanvasPosPresent = tempX;
	tilePosArray0[tile1Index].yCanvasPosPresent = tempY;

	ctx1.clearRect(0, 0, iWidth, iHeight);
	for (let k = 0; k < tilePosArray0.length; k++) {
		ctx1.drawImage(
			sourceImg,
			tilePosArray0[k].x0,
			tilePosArray0[k].y0,
			...tileDimArray0,
			tilePosArray0[k].xCanvasPosPresent,
			tilePosArray0[k].yCanvasPosPresent,
			...tileDimArrayScaled
		);
	}
	checkProperPostion();
	checkWinCondition();
}

// check if swapped tile went to proper position
function checkProperPostion() {
	let tileX1 = tilePosArray0[tile1Index].xCanvasPosPresent === tilePosArray0[tile1Index].xCanvasPosProper;
	let tileY1 = tilePosArray0[tile1Index].yCanvasPosPresent === tilePosArray0[tile1Index].yCanvasPosProper;
	let tileX2 = tilePosArray0[tile2Index].xCanvasPosPresent === tilePosArray0[tile2Index].xCanvasPosProper;
	let tileY2 = tilePosArray0[tile2Index].yCanvasPosPresent === tilePosArray0[tile2Index].yCanvasPosProper;

	if ((tileX1 && tileY1) || (tileX2 && tileY2)) {
		countScore();
	}
}

// updates score based on number of moves made. only display score if greater than or equal to zero
function countScore() {
	let multiplier = swapCount - difficulty * 2;
	multiplier <= 0 ? (score += 5) : (score -= 5);
	scoreDisplay.innerHTML = score >= 0 ? `Score: ${score}` : 'Score: 0';
}

// loops over tilePosArray0 to compare x / y values for proper and present position in current object
// if not equal, keep playing. If entire array has been checked and all items are equal, then puzzle has been solved.
function checkWinCondition() {
	for (let i = 0; i < tilePosArray0.length; i++) {
		if (
			tilePosArray0[i]['xCanvasPosProper'] !== tilePosArray0[i]['xCanvasPosPresent'] ||
			tilePosArray0[i]['yCanvasPosProper'] !== tilePosArray0[i]['yCanvasPosPresent']
		) {
			return;
		}
	}
	puzzleSolved = true;
	displayEndScreen('Congratulations!');
}

// turn off eventListener, display congrats and return to intro screen
function displayEndScreen(message) {
	canvas1.removeEventListener('mousedown', getCursorPos);
	puzzleSound.pause();
	ctx1.fillStyle = 'rgba(0, 0, 0, 0.35)';
	ctx1.fillRect(0, iHeight / 3, iWidth, iHeight / 4);
	ctx1.save();
	if(puzzleSolved){
		winSound.play();
		ctx1.font = 'bold 75px Arial';
		ctx1.fillStyle = 'White';
		document.querySelector('#information').style.backgroundColor = 'White';
		appendInfo();
	}
	else {
		loseSound.play();
		ctx1.font = 'bold 95px Arial';
		ctx1.fillStyle = 'Red';
	}
	ctx1.textAlign = 'center';
	ctx1.textBaseline = 'bottom';
	ctx1.fillText(message, iWidth / 2, iHeight / 2);
	ctx1.textBaseline = 'top';
	ctx1.font = 'bold 20px Arial';
	ctx1.fillText('Refresh to play again', iWidth / 2, iHeight / 2);
}

// if puzzle solved, display information about picture
function appendInfo() {
	let h3 = document.createElement('h3');
	let p2 = document.createElement('p');
	let p3 = document.createElement('p');
	let a1 = document.createElement('a');
	let infoDiv = document.querySelector('#information');

	switch (category) {
		case 'food':
			let p4 = document.createElement('p');

			h3.innerHTML = edamRecipeLabel;
			p2.innerHTML = 'Calories: ' + Math.floor(1 * edamRecipeCalories);
			a1.setAttribute('href', `${edamRecipeUrl}`);
			a1.setAttribute('target', '_blank');
			a1.innerText = 'here';
			p3.innerHTML = `Find recipe `;
			p3.appendChild(a1);
			p4.innerHTML = edamRecipeIngredients;

			infoDiv.innerHTML = '';
			infoDiv.appendChild(h3);
			infoDiv.appendChild(p2);
			infoDiv.appendChild(p4);
			infoDiv.appendChild(p3);
			break;
		case 'movies':
			console.log([nytImgTitle,nytImgDate,nytImgHeadline,nytImgReviewUrl])
			h3.innerHTML = nytImgTitle;
			p2.innerHTML = "Release Date: " + nytImgDate;
			p3.innerHTML = nytImgHeadline + '. ';
			a1.setAttribute('href', `${nytImgReviewUrl}`);
			a1.setAttribute('target', '_blank');
			a1.innerText = 'Read review';
			p3.appendChild(a1);

			infoDiv.innerHTML = '';
			infoDiv.appendChild(h3);
			infoDiv.appendChild(p2);
			infoDiv.appendChild(p3);
			break;
		case 'space':
			h3.innerHTML = nasaImgTitle;
			p2.innerHTML = "Date Posted: " + nasaImgDate;
			p3.innerHTML = nasaImgExplanation + ' ';
			a1.setAttribute('href', `${nasaImgUrl}`);
			a1.setAttribute('target', '_blank');
			a1.innerText = 'Better image';
			p3.appendChild(a1);

			infoDiv.innerHTML = '';
			infoDiv.appendChild(h3);
			infoDiv.appendChild(p2);
			infoDiv.appendChild(p3);
			break;
	}
}

// for debugging - prints cursor x/y values, image size and position
function debugVals(e) {
	let pLog = document.getElementById('mouseCoords');
	pLog.style.fontSize = '10px';

	pLog.innerHTML = `Screen [X,Y]: [${e.screenX},${e.screenY}]<p> Client[X,Y]:
	[${e.clientX},${e.clientY}]</p><p>Tile Pos Array2 Length: ${tilePosArray0.length}</p><p>Tile Dim2: x-${tileDimArrayScaled[0]} y-${tileDimArrayScaled[1]}</p><p>Tile Pos Arr ulCoord: x-${tilePosArray0[0]
		.x0} y-${tilePosArray0[0]
		.y0}</p><p>Canvas width: ${canvas1.width}</p><p>Canvas height: ${canvas1.height}</p><p>Image width: ${iWidth}</p><p>Image height: ${iHeight}</p><p>Image Natural width: ${sourceImg.naturalWidth}</p><p>Image Natural height: ${sourceImg.naturalHeight}</p>`;
}
