//menu responsive bar
$(document).ready(function () {
  $('.menu-toggle').click(function () {
    $('nav').toggleClass('active')
  })
})

//dice
var dice = new Array();
var dice1;
var dice2;
var dice3;
var dice4;
var dice5;


// running totals
var numberOfThreeOfAKind = 0;
var numberOfFourOfAKind = 0;
var numberOfFullHouse = 0;
var numberOfSmallStraight = 0;
var numberOfLargeStraight = 0;
var numberOfYahtzee = 0;
var numberOfChance = 0;
var scores = new Array();
var numberOfRolls = 0;
var totalScore = 0;

document.querySelector("#roll button").addEventListener("click", TryToGetYahtzee);

function rollDice() {
  dice.splice(0, dice.length);

  randomDice();
}

function randomDice() {

  dice1 = RollDie();
  dice.push(dice1);
  //setImage(0, dice1);

  dice2 = RollDie();
  dice.push(dice2);
  //setImage(1, dice2);

  dice3 = RollDie();
  dice.push(dice3);
  //setImage(2, dice3);

  dice4 = RollDie();
  dice.push(dice4);
  //setImage(3, dice4);

  dice5 = RollDie();
  dice.push(dice5);
  //setImage(4, dice5);
}

// deze functie geeft een plaatje weer van een dobbelsteenwaarde (diceValue) op de aangegeven plaats (num)
function setImage(num, diceValue) {
  return document.querySelectorAll('.dice')[num].setAttribute('src', 'dice/dice' + diceValue + '.png');
}

// deze functie genereerd een willekeurig getal tussen een minimum (min) en een maximum (max) cijfer
function GetNewRandom(min, max) {
  return Math.floor(Math.random() * (max - min + 1)) + min;
}

// deze functie vraagt een willekeurig getal tussen 1 en 6 (voor een d6)
function RollDie() {
  return GetNewRandom(1, 6);
}

// deze functie gooit dice totdat er yahtzee gegooid is.
function TryToGetYahtzee() {
  do {
    rollDice();
    numberOfRolls++
    dice.sort();
    Results();
  } while (numberOfYahtzee == 0)
  showResult();

  // reset scores
  numberOfThreeOfAKind = 0;
  numberOfFourOfAKind = 0;
  numberOfFullHouse = 0;
  numberOfSmallStraight = 0;
  numberOfLargeStraight = 0;
  numberOfYahtzee = 0;
  numberOfChance = 0;
  numberOfRolls = 0;
  totalScore = 0;
}

// deze functie haalt de resultaten van de worp op.
function Results() {
  scores.splice(0, scores.length)
  scores.push(ThreeOfAKind());
  scores.push(FourOfAKind());
  scores.push(FullHouse());
  scores.push(SmallStraight());
  scores.push(LargeStraight());
  scores.push(Yahtzee());
  scores.push(Chance());

  // tel de hoogste score bij het totaal op.
  scores.sort();
  totalScore += scores[scores.length - 1];
}

// deze functie schijft resultaat voor three of a kind
function ThreeOfAKind() {
  if (IsThreeOfAKind()) {
    numberOfThreeOfAKind++;
    return sumTotalDice();
  } else {
    return 0;
  }
}

// deze functie schijft resultaat voor four of a kind
function FourOfAKind() {
  if (IsFourOfAKind()) {
    numberOfFourOfAKind++;
    return sumTotalDice();
  } else {
    return 0;
  }
}

// deze functie schijft resultaat voor full house
function FullHouse() {
  if (IsFullHouse()) {
    numberOfFullHouse++
    return 25;
  } else {
    return 0;
  }
}

// deze functie schijft resultaat voor kleine straat
function SmallStraight() {
  if (IsSmallStraight()) {
    numberOfSmallStraight++
    return 30;
  } else {
    return 0;
  }
}

// deze functie schijft resultaat voor groote straat
function LargeStraight() {
  if (IsLargeStraight()) {
    numberOfLargeStraight++
    return 40;
  } else {
    return 0;
  }
}

// deze functie schijft resultaat voor Yathzee
function Yahtzee() {
  if (IsYahtzee()) {
    numberOfYahtzee++
    return 50;
  } else {
    return 0;
  }
}

// deze functie schijft resultaat voor Chance
function Chance() {
  numberOfChance++
  return sumTotalDice()
}

// deze functie schrijft de resultaten naar het juiste element
function showResult() {
  //show the yahtzee
  setImage(0, dice1); setImage(1, dice2); setImage(2, dice3); setImage(3, dice4); setImage(4, dice5);

  //show stats in tabel
  document.getElementById("threeOfAKind").innerHTML = numberOfThreeOfAKind;
  document.getElementById("fourOfAKind").innerHTML = numberOfFourOfAKind;
  document.getElementById("fullHouse").innerHTML = numberOfFullHouse;
  document.getElementById("kleineStraat").innerHTML = numberOfSmallStraight;
  document.getElementById("groteStraat").innerHTML = numberOfLargeStraight;
  document.getElementById("yahtzee").innerHTML = numberOfYahtzee;
  document.getElementById("yahtzee").style.backgroundColor='#43A047';
  document.getElementById("yahtzee").style.color='white';
  document.getElementById("chance").innerHTML = numberOfChance;
  document.getElementById("gemPunten").innerHTML = Math.floor((totalScore / numberOfRolls)*10)/10;
  document.getElementById("totaal").innerHTML = totalScore;
}




for (const button of document.querySelectorAll("button.scoreBlokje")) {
  button.addEventListener("click", function(){
    button.classList.toggle("scoreBlokje");
    button.classList.toggle("toggleScoreButton");
  })
};



// deze functie kijkt of het de worp (dice (gesorteerd)) een three of a kind is.
function IsThreeOfAKind() {
  if (dice[0] == dice[1] && dice[0] == dice[2] ||
    dice[1] == dice[2] && dice[1] == dice[3] ||
    dice[2] == dice[3] && dice[2] == dice[4]) {
    return true;
  }
  return false;
}

// deze functie kijkt of het de worp (dice (gesorteerd)) een four of a kind is.
function IsFourOfAKind() {
  if (dice[0] == dice[1] && dice[0] == dice[2] && dice[0] == dice[3] ||
    dice[1] == dice[2] && dice[1] == dice[3] && dice[1] == dice[4]) {
    return true;
  }
  return false;
}

// deze functie kijkt of het de worp (dice (gesorteerd)) een full house is.
function IsFullHouse() {
  if (dice[0] == dice[1] && dice[0] == dice[2] && dice[3] == dice[4] ||
    dice[2] == dice[3] && dice[2] == dice[4] && dice[0] == dice[1]) {
    return true;
  }
  return false;
}

// deze functie kijkt of het de worp (dice (gesorteerd)) een kleine straat is.
function IsSmallStraight() {
  if (dice.includes(1) && dice.includes(2) && dice.includes(3) && dice.includes(4) ||
    dice.includes(2) && dice.includes(3) && dice.includes(4) && dice.includes(5) ||
    dice.includes(3) && dice.includes(4) && dice.includes(5) && dice.includes(6)) {
    return true;
  }
  return false;
}

// deze functie kijkt of het de worp (dice (gesorteerd)) een groote straat is.
function IsLargeStraight() {
  if (dice.includes(1) && dice.includes(2) && dice.includes(3) && dice.includes(4) && dice.includes(5) ||
    dice.includes(2) && dice.includes(3) && dice.includes(4) && dice.includes(5) && dice.includes(6)) {
    return true;
  }
  return false;
}

// deze functie kijkt of het de worp (dice (gesorteerd)) een Yahtzee is.
function IsYahtzee() {
  if (dice[0] == dice[1] && dice[0] == dice[2] && dice[0] == dice[3] && dice[0] == dice[4]) {
    return true;
  }
  return false;
}

function sumTotalDice() {
  return dice[0] + dice[1] + dice[2] + dice[3] + dice[4];
}
