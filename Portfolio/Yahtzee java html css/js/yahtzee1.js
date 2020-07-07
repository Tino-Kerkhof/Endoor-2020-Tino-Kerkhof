//menu responsive bar
$(document).ready(function(){
  $('.menu-toggle').click(function(){
    $('nav').toggleClass('active')
  })
})

var dice = new Array();
var dice1;
var dice2;
var dice3;
var dice4;
var dice5;
var result;

document.querySelector("#roll button").addEventListener("click", rollDice);

function rollDice() {
  dice.splice(0, dice.length);

  randomDice();
  Results();
}

function randomDice(){

  dice1 = RollDie();
  dice.push(dice1);
  setImage(0, dice1);

  dice2 = RollDie();
  dice.push(dice2);
  setImage(1, dice2);

  dice3 = RollDie();
  dice.push(dice3);
  setImage(2, dice3);

  dice4 = RollDie();
  dice.push(dice4);
  setImage(3, dice4);

  dice5 = RollDie();
  dice.push(dice5);
  setImage(4, dice5);
}

// deze functie geeft een plaatje weer van een dobbelsteenwaarde (diceValue) op de aangegeven plaats (num)
function setImage(num, diceValue){
  return document.querySelectorAll('.dice')[num].setAttribute('src', 'dice/dice'+diceValue+'.png');
}

// deze functie genereerd een willekeurig getal tussen een minimum (min) en een maximum (max) cijfer
function GetNewRandom(min, max){
  return Math.floor(Math.random() * (max - min + 1)) + min;
}

// deze functie vraagt een willekeurig getal tussen 1 en 6 (voor een d6)
function RollDie() {
  return GetNewRandom(1,6);
}

// deze functie haalt de resultaten van de worp op.
function Results() {
  dice.sort();
  var result = "";
  result += ThreeOfAKind();
  result += FourOfAKind();
  result += FullHouse();
  result += SmallStraight();
  result += LargeStraight();
  result += Yatzhee();
  result += Chance();
  showResult(result)
}

// deze functie schijft resultaat voor three of a kind
function ThreeOfAKind() {
  if (IsThreeOfAKind())
  {
    return "<p class=\"yesScore\">De worp is een Three of a Kind.</p>";
  } else {
    return "";
  }
}

// deze functie schijft resultaat voor four of a kind
function FourOfAKind() {
  if (IsFourOfAKind())
  {
    return "<p class=\"yesScore\">De worp is een Four of a Kind.</p>";
  } else {
    return "";
  }
}

// deze functie schijft resultaat voor full house
function FullHouse() {
  if (IsFullHouse())
  {
    return "<p class=\"yesScore\">De worp is een Full House.</p>";
  } else {
    return "";
  }
}

// deze functie schijft resultaat voor kleine straat
function SmallStraight() {
  if (IsSmallStraight())
  {
    return "<p class=\"yesScore\">De worp is een Kleine Straat.</p>";
  } else {
    return "";
  }
}

// deze functie schijft resultaat voor groote straat
function LargeStraight() {
  if (IsLargeStraight())
  {
    return "<p class=\"yesScore\">De worp is een Groote Straat.</p>";
  } else {
    return "";
  }
}

// deze functie schijft resultaat voor Yathzee
function Yatzhee() {
  if (IsYatzhee())
  {
    return "<p class=\"yesScore\">De worp is Yatzhee.</p>";
  } else {
    return "";
  }
}

// deze functie schijft resultaat voor Chance
function Chance() {
  return "<p class=\"yesScore\">Chance geeft " + sumTotalDice() + " punten</p>"
}

// deze functie schrijft de resultaten naar het juiste element
function showResult(result) {
    document.querySelector("#result h3 span").innerHTML = result;
}

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

// deze functie kijkt of het de worp (dice (gesorteerd)) een Yatzhee is.
function IsYatzhee() {
  if (dice[0] == dice[1] && dice[0] == dice[2] && dice[0] == dice[3] && dice[0] == dice[4]) {
      return true;
    }
    return false;
}

function sumTotalDice() {
  return dice[0] + dice[1] + dice[2] + dice[3] + dice[4];
}
